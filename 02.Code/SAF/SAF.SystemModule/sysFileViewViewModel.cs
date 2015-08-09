using SAF.Framework.ViewModel;
using SAF.SystemEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;
using SAF.Foundation.ComponentModel;
using System.Reflection;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;

namespace SAF.SystemModule
{
    public class sysFileViewViewModel : SingleViewViewModel<sysFile, sysFile>
    {

        private EntitySet<sysBusinessView> _BusinessViewEntitySet = null;
        public EntitySet<sysBusinessView> BusinessViewEntitySet
        {
            get
            {
                if (_BusinessViewEntitySet == null)
                {
                    _BusinessViewEntitySet = new EntitySet<sysBusinessView>(this.ExecuteCache, 0);
                }
                return _BusinessViewEntitySet;
            }
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysFile> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsActive = true;
        }

        protected override void OnQuery(string sCondition, params object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("select Iden, Name, FileVersion, FileSize from sysFile with(nolock) where {0}".FormatWith(sCondition), parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            this.MainEntitySet.Query("select Iden, Name, FileName, FileVersion, FileData=cast(null as image), FileSize, LastWriteTime, Remark, IsActive, IsSystem, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, VersionNumber from sysFile with(nolock) where Iden=:Iden", key);
        }

        internal bool UpdateFiles(List<string> list)
        {
            ProgressService.Show("正在上传文件");
            try
            {
                foreach (var fileName in list)
                {
                    string name = Path.GetFileName(fileName).Trim();
                    var obj = this.MainEntitySet.Select("Select top 1 Iden, Name, FileName, FileVersion,  FileData=cast(null as image),FileSize, LastWriteTime, Remark, IsActive,IsSystem, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, VersionNumber from sysFile with(nolock) where Name=:Name", name);
                    if (obj.Count <= 0)
                    {
                        this.AddNew();
                        if (MainEntitySet.CurrentEntity != null)
                        {
                            MainEntitySet.CurrentEntity.IsSystem = false;
                            FileHelper.SetFileInfo(MainEntitySet.CurrentEntity, fileName);
                            this.SyncIndexEntitySet();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < obj.Count; i++)
                        {
                            if (this.MainEntitySet.FirstOrDefault(p => p.Name.Equals(Path.GetFileName(fileName), StringComparison.InvariantCultureIgnoreCase)) == null)
                                this.MainEntitySet.Import(obj[i]);
                            var entity = this.MainEntitySet.FirstOrDefault(p => p.Name == Path.GetFileName(fileName));
                            if (entity != null)
                            {
                                FileHelper.SetFileInfo(entity, fileName);
                                var index = this.IndexEntitySet.FirstOrDefault(p => p.Name == Path.GetFileName(fileName));
                                if (index != null)
                                {
                                    index.Copy(entity);
                                    this.IndexEntitySet.AcceptChanges();
                                }
                            }
                        }
                    }
                }
                ParseBusinessView(list);
                ProgressService.Close();
                return true;
            }
            catch (Exception ex)
            {
                ProgressService.Abort();
                MessageService.ShowException(ex);
                return false;
            }
        }

        protected override void OnApplySave()
        {
            base.OnApplySave();
            this.BusinessViewEntitySet.SaveChanges();
        }

        protected override void OnAfterSave(bool saveSucceed)
        {
            base.OnAfterSave(saveSucceed);

            this.BusinessViewEntitySet.AcceptChanges();
            this.BusinessViewEntitySet.Clear();
        }

        class ViewTypeInfo
        {
            public string FileName { get; set; }
            public string TypeName { get; set; }
            public string Description { get; set; }
        }

        private void ParseBusinessView(List<string> files)
        {
            this.BusinessViewEntitySet.Clear();

            var listFile = new List<string>();
            var listView = new List<ViewTypeInfo>();

            AppDomain ad = AppDomain.CreateDomain("ParseBusinessView Type Management");
            try
            {
                LoadAssemblyProxyObject obj = (LoadAssemblyProxyObject)ad.CreateInstanceFromAndUnwrap(LoadAssemblyProxyObject.AssemblyFileName, LoadAssemblyProxyObject.ProxyObjectTypeName);
                foreach (var fileName in files)
                {
                    if (!Path.GetExtension(fileName).Equals(".dll", StringComparison.InvariantCultureIgnoreCase)
                        && !Path.GetExtension(fileName).Equals(".exe", StringComparison.InvariantCultureIgnoreCase)) continue;

                    if (obj.LoadAssembly(fileName))
                    {
                        if (!listFile.Contains(Path.GetFileName(fileName)))
                        {
                            var types = obj.GetAllTypeMarked<BusinessObjectAttribute>();

                            if (types.Count > 0)
                                listFile.Add(Path.GetFileName(fileName));

                            foreach (Type item in types)
                            {
                                var boAttr = item.GetCustomAttribute<BusinessObjectAttribute>();
                                var view = new ViewTypeInfo() { FileName = Path.GetFileName(fileName), TypeName = item.FullName };
                                view.Description = boAttr == null ? string.Empty : boAttr.Description;
                                listView.Add(view);
                            }
                        }
                    }
                }
            }
            finally
            {
                AppDomain.Unload(ad);
            }

            string sql = @"
SELECT a.Iden, a.ClassName,a.Description, a.FileId, a.Remark, a.IsDeleted,FileName= b.Name,
    a.CreatedBy, a.CreatedOn, a.ModifiedBy, a.ModifiedOn, a.VersionNumber 
FROM [dbo].[sysBusinessView] a with(nolock)
JOIN [dbo].[sysFile] b with(nolock) ON a.[FileId]=b.[Iden]
WHERE b.[Name] in ({0})".FormatWith("'" + listFile.JoinText("','") + "'");

            BusinessViewEntitySet.Query(sql);

            foreach (var type in listView)
            {
                var viewInfo = BusinessViewEntitySet.FirstOrDefault(p => p.GetFieldValue<string>("FileName") == type.FileName && p.ClassName == type.TypeName);
                if (viewInfo == null)
                {
                    viewInfo = BusinessViewEntitySet.AddNew();
                    viewInfo.Iden = IdenGenerator.NewIden(viewInfo.IdenGroup);
                    viewInfo.ClassName = type.TypeName;
                    viewInfo.FileId = GetFileId(type.FileName);
                    viewInfo.Description = type.Description;
                }
                else
                {
                    viewInfo.Description = type.Description;
                }
                viewInfo.IsDeleted = false;
            }
        }

        private int GetFileId(string fileName)
        {
            var obj = this.IndexEntitySet.FirstOrDefault(p => p.Name == fileName);
            if (obj != null)
            {
                return obj.Iden;
            }
            return -1;
        }

        public void SelectFile()
        {
            if (this.EditState.In(EditState.AddNew, EditState.Edit))
            {
                var fileName = FileDialogHelper.OpenFile("选择文件...");
                if (!fileName.IsEmpty() && File.Exists(fileName) && MainEntitySet.CurrentEntity != null)
                {
                    FileHelper.SetFileInfo(MainEntitySet.CurrentEntity, fileName);
                    this.SyncIndexEntitySet();
                }
            }
        }

        protected override void OnInitQueryConfig(Framework.Controls.QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new Framework.Controls.QueryField("Name", "文件名称"));
        }

        protected override bool OnAllowDelete()
        {
            var canDelete = true;
            var fileName = string.Empty;
            if (this.MainEntitySet.CurrentEntity != null)
            {
                if (this.MainEntitySet.CurrentEntity.IsSystem)
                {
                    canDelete = false;
                }
                fileName = this.MainEntitySet.CurrentEntity.Name;
            }
            if (!canDelete)
            {
                MessageService.ShowError("\"{0}\"是系统文件,不允许删除!".FormatWith(fileName));
            }

            return canDelete;
        }
    }
}
