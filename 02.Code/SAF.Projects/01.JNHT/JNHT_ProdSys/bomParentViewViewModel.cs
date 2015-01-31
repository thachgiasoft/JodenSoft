using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;
using System.Data;

namespace JNHT_ProdSys
{
    public class bomParentViewViewModel : SingleViewViewModel<bomParent, bomParent>
    {
        public static string Bomid = "1";

        private EntitySet<bomParent> _bomEntity = null;
        public EntitySet<bomParent> bomEntity
        {
            get
            {
                if (_bomEntity == null)
                    _bomEntity = new EntitySet<bomParent>(ConfigContext.DefaultConnection, null, 0);
                return _bomEntity;
            }
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);
            
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));
        }

        //Iden,BomParentId,BomParentDesc,BomParentStyle
        //SUBSTRING(bomParentid,CHARINDEX('-',bomparentid,0)+1,LEN(BomParentId)-CHARINDEX('-',bomparentid,0))=RIGHT('0000000000000000',LEN(BomParentId)-CHARINDEX('-',bomparentid,0))  and
        protected override void OnQueryChild(object key)
        {
            //base.OnQueryChild(key);
            this.MainEntitySet.PageSize = 0;
            var bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;

            //this.bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,UseQty  from bomparent with(nolock) where BomId='{0}' ".FormatEx(bomId));

            this.MainEntitySet.Query("select BomId,Iden,BomParentId,BomParentDesc,BomParentStd,BomParentStyle,BomChildId,BomChildDesc,BomChildStd,UseQty,BomChildStyle from  bomParent with(nolock) where BomId='{0}' ".FormatEx(bomId));

        }

        #region 导入bom

        public bool OnImportBomParent(DataTable dt, string bomid)
        {
            //定义childid 和 childname 存放上一条数据
            string childid = "";
            string childname = "";
            //定义一个bool变量
            bool result = false;
            //定义变量,存放部件属性
            string bomProperty = "";
            //定义bomid以便查询时候查得同一款产品,bomid中放总装产品图号
            //string bomid = "";
            //定义变量存放存货名称前缀(螺钉,螺丝之类)
            string preName = "";
            //定义变量存放bomchildid
            string bomchildid = "";
            //设置循环变量
            int i = 0;
            try
            {

                foreach (System.Data.DataRow item in dt.Rows)
                {
                    //当第三列的值包含件的时候,并且第四列的值为空的,说明是大类的开始,记下值当作属性
                    if (item[2].ToString().Trim().Contains("件") && string.Empty.Equals(item[3].ToString().Trim()))
                    {
                        bomProperty = item[2].ToString().Trim();
                        preName = "";
                        i++;
                        continue;
                    }
                    //当第三列的值为螺钉螺丝类,把前缀记下
                    if (!item[2].ToString().Trim().Contains("件") && string.IsNullOrEmpty(item[3].ToString().Trim()))
                    {
                        preName = item[2].ToString().Trim();
                        i++;
                        continue;
                    }
                    //如果是标准件的childid等于childid+子件规格  
                    if (!string.IsNullOrEmpty(preName))
                    {
                        bomchildid = item[1].ToString().Trim() + item[2].ToString().Trim();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item[1].ToString().Trim()) && string.IsNullOrEmpty(item[2].ToString().Trim()))
                        {
                            bomchildid = childid;
                            
                        }
                        else if (string.IsNullOrEmpty(item[1].ToString().Trim()))
                        {
                            bomchildid = item[2].ToString().Trim();

                        }
                        else
                        {
                            bomchildid = item[1].ToString().Trim();
                        }

                    }

                    //构造bomparent对象
                    EntitySet<bomParent> entity = new EntitySet<bomParent>();
                    entity.Query("select * from  bomParent with(nolock) where 1=0");
                    bomParent bom = entity.AddNew();

                    if (isBomExists(item[3].ToString().Trim(),bomid, bomchildid))
                        continue;

                    bom.Iden = IdenGenerator.NewIden("bomparent");
                    bom.BomId = bomid;
                    bom.BomParentId = item[3].ToString().Trim();
                    bom.BomParentStd = null;
                    bom.BomParentStyle = null;
                    bom.BomParentDesc = null;
                    bom.BomChildId = bomchildid;
                    bom.BomChildDesc = string.IsNullOrEmpty(item[2].ToString().Trim()) ? childname : item[2].ToString().Trim();
                    bom.BomChildStyle = bomProperty;
                    bom.BomChildStd = preName;
                    bom.UseQty = Convert.ToDecimal(item[4].ToString().Trim());
                    bom.Define1 = item[7].ToString().Trim();
                    entity.SaveChanges();

                    childid = item[1].ToString().Trim();
                    childname = item[2].ToString().Trim();
                }
                result = true;


            }
            catch (Exception ex)
            {

                throw ex;

            }
            return result;
        }

        #region 是否导入过
        private bool isBomExists(string isparentid,string isbomid, string isbomchildid)
        {
            EntitySet<bomParent> bomentity = new EntitySet<bomParent>();
            bomentity.Query("select * from  bomParent with(nolock) where bomid='{0}' and BomChildId='{1}' and bomparentid='{2}'".FormatEx(isbomid, isbomchildid,isparentid));
            if (bomentity.Count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #endregion
        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BomId", "产品区分号"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<bomParent> e)
        {

            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);

        }



        internal bool deleteprod(string bomid)
        {
           
            EntitySet<bomParent> bomparentEntity = new EntitySet<bomParent>();
            bomparentEntity.Query("select * from bomparent where bomid='{0}'".FormatEx(bomid));
            for (int i = bomparentEntity.Count - 1; i >= 0; i--)
            {
                bomparentEntity.DeleteEntity(bomparentEntity[i]);
                bomparentEntity.SaveChanges();
            }


            return true;

        }
    }
}
