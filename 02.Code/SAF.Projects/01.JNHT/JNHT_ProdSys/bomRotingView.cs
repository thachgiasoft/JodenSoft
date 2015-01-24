using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
//using JNHT_ProdSys.Method;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;
using System.Xml.Serialization;
using System.IO;
using SAF.EntityFramework;
using SAF.Foundation;

namespace JNHT_ProdSys
{
    [BusinessObject("bomRotingView")]
    public partial class bomRotingView : SingleView
    {
        public bomRotingView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new bomRotingViewViewModel();
        }

        public new bomRotingViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as bomRotingViewViewModel;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.groupCooperation.Visible = false;
            this.groupReport.Visible = false;
        }
        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();
            var MyExport = new DefaultRibbonMenuCommand("导入", MyExportExcute) { LargeGlyph = Properties.Resources.Action_ImportData_32x32 };
            this.AddRibbonMenuCommand(MyExport);
        }
        
        private void MyExportExcute(object obj)
        {
            //if (rgleixing.SelectedIndex == 0)
            //    MessageBox.Show(rgleixing.SelectedIndex.ToString());
            //return;
            //多选获取路径

            string[] filenames = myOpenfile();
            for (int i = 0; i < filenames.Length; i++)
            {
                try
                {
                    if (rgleixing.SelectedIndex == 0)
                    {
                        readXmljp(filenames[i]);
                    }
                    else
                    {
                       readXml(filenames[i]);
                    }
                      
                      
                }
                catch (Exception ex )
                {
                    
                    throw ex;
                }
               

            }
            MessageService.ShowMessage("导入成功");
         
        }

        private void readXmljp(string filename)
        {
            XmlSerializer xml = new XmlSerializer(typeof(开目信息文件));
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                开目信息文件 obj = (开目信息文件)xml.Deserialize(file);

                //MessageBox.Show(obj.数据.元素["产品代号"].Value);//.下级信息[0].数据[0].元素[0].标识

                // MessageBox.Show(obj.数据.元素.FirstOrDefault(p => p.标识 == "产品代号").标识);
                for (int i = 0; i < obj.数据.下级信息[0].数据.Count(); i++)
                {
                    EntitySet<bomRoting> entity = new EntitySet<bomRoting>();
                    entity.Query("select * from  bomRoting with(nolock) where 1=0");
                    bomRoting bm = entity.AddNew();
                    bm.Iden = IdenGenerator.NewIden("bomRoting");
                    bm.BomId = obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value.Substring(0, obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value.IndexOf("-"));
                    bm.BomChildId = string.IsNullOrEmpty(obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value) ? string.Empty : obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value;
                    bm.OpDep = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "生产部门").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "生产部门").Value;
                    bm.RotingId = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序号").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序号").Value;
                    bm.RotingName = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序名称").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序名称").Value;
                    bm.RotingDesc = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序内容").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序内容").Value;
                    var Production = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "设备");
                    if (Production == null)
                    {
                        bm.Production = string.Empty;
                    }
                    else
                    {
                        bm.Production = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "设备").Value;
                    } 
                    var RotingProduction=obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工艺装备");
                    if(RotingProduction==null) 
                    {
                        bm.RotingProduction=string.Empty;
                    }
                    else
                    {
                        bm.RotingProduction = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工艺装备").Value;
                    }

                    var FZMeterial = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "辅助材料");
                    if (FZMeterial == null)
                    {
                        bm.FZMeterial = string.Empty;
                    }
                    else
                    {
                        bm.FZMeterial = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "辅助材料").Value;
                    } 
                   
                    var ZhunJie = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "准结");
                    if (ZhunJie == null)
                    {
                        bm.ZhunJie =0;
                    }
                    else
                    {
                        bm.ZhunJie =Convert.ToDecimal(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "准结").Value);
                    } 
                   var DanJian = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "单件");
                    if (DanJian == null)
                    {
                        bm.DanJian = 0;
                    }
                    else
                    {
                        bm.DanJian = Convert.ToDecimal(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "单件").Value);
                    } 
                    if (isExportBomRoting(bm.BomId, bm.BomChildId, bm.RotingId))
                        continue;
                    entity.SaveChanges();
                }


            }
        }

        private void readXml(string filename)
        {

            XmlSerializer xml = new XmlSerializer(typeof(开目信息文件));
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                开目信息文件 obj = (开目信息文件)xml.Deserialize(file);

                //MessageBox.Show(obj.数据.元素["产品代号"].Value);//.下级信息[0].数据[0].元素[0].标识

               // MessageBox.Show(obj.数据.元素.FirstOrDefault(p => p.标识 == "产品代号").标识);
                for (int i = 0; i < obj.数据.下级信息[0].数据.Count(); i++)
                {
                    EntitySet<bomRoting> entity = new EntitySet<bomRoting>();
                    entity.Query("select * from  bomRoting with(nolock) where 1=0");
                    bomRoting bm = entity.AddNew();
                    bm.Iden = IdenGenerator.NewIden("bomRoting");
                    bm.BomId = obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value.Substring(0, obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value.IndexOf("-"));
                    bm.BomChildId = string.IsNullOrEmpty(obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value) ? string.Empty : obj.数据.元素.FirstOrDefault(p => p.标识 == "零部组件代号").Value;
                    bm.OpDep = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工段代号").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工段代号").Value;
                    bm.RotingId = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序号").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序号").Value;
                    bm.RotingName = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序名称").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序名称").Value;
                    bm.RotingDesc = string.IsNullOrEmpty(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序内容").Value) ? string.Empty : obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工序内容").Value;
                    var Production = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "设备");
                    if (Production == null)
                    {
                        bm.Production = string.Empty;
                    }
                    else
                    {
                        bm.Production = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "设备").Value;
                    }
                    var RotingProduction = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工艺装备");
                    if (RotingProduction== null)
                    {
                        bm.RotingProduction = string.Empty;
                    }
                    else
                    {
                        bm.RotingProduction = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "工艺装备").Value;
                    }

                    var FZMeterial = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "辅助材料");
                    if (FZMeterial == null)
                    {
                        bm.FZMeterial = string.Empty;
                    }
                    else
                    {
                        bm.FZMeterial = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "辅助材料").Value;
                    }
                    var ZhunJie = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "准结");
                    if (ZhunJie == null)
                    {
                        bm.ZhunJie = 0;
                    }
                    else
                    {
                        bm.ZhunJie = Convert.ToDecimal(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "准结").Value);
                    }
                    var DanJian = obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "单件");
                    if (DanJian == null)
                    {
                        bm.DanJian = 0;
                    }
                    else
                    {
                        bm.DanJian = Convert.ToDecimal(obj.数据.下级信息[0].数据[i].元素.FirstOrDefault(p => p.标识 == "单件").Value);
                    } 
                    if (isExportBomRoting(bm.BomId, bm.BomChildId, bm.RotingId))
                        continue;
                    entity.SaveChanges();
                }


            }

        }

        private bool isExportBomRoting(string bomid, string bomchildid, string rotingid)
        {
            EntitySet<bomRoting> bomentity = new EntitySet<bomRoting>();
            bomentity.Query("select * from  bomRoting with(nolock) where bomid='{0}' and BomChildId='{1}' and RotingId='{2}'".FormatEx(bomid, bomchildid, rotingid));
            if (bomentity.Count > 0)
                return true;
            else
                return false;
        }
        


        private string[] myOpenfile()
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择XML文件...";
                openFileDialog.Filter = "xml文件(*.xml)|*.xml";
                openFileDialog.Multiselect = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DefaultExt = "xml";
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
                else
                {
                    return null;
                }
            }

        }
        //移除空行
        private DataTable ReMoveRow(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (dt.Rows[i][j].ToString().Trim() != "")
                    {

                        rowdataisnull = false;
                    }
                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            return dt;
        }
    }
}
