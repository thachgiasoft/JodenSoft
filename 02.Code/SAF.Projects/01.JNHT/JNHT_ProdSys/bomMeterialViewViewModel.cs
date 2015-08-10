using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;

namespace JNHT_ProdSys
{
    public class bomMeterialViewViewModel : SingleViewViewModel<bomMeterial, bomMeterial>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            //base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT distinct Iden=0, BomId  from bomParent with(nolock) where ({0})".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            MainEntitySet.PageSize = 0;
            //base.OnQueryChild(key);
            var bomId = this.IndexEntitySet.CurrentEntity == null ? string.Empty : this.IndexEntitySet.CurrentEntity.BomId;

            //this.bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc,UseQty  from bomparent with(nolock) where BomId='{0}' ".FormatEx(bomId));

            this.MainEntitySet.Query(@" SELECT Iden,BomId,BomChildId,BomChildName,CInvCode,CInvName,ShopSign
                                        ,Invstd,FeedStd,SingleNum,Weight,OneMakeNum,SingleQty,CComUnitCode
                                         ,ProcQty,NetWeight,MaterialRate,Production,Mark2,Proportion,PartNetWeight
                                         ,OpDep,define1,define2,define3,define4,define5,define6,define7,define8
                                          ,define9,define10
                                            FROM dbo.bomMeterial with(nolock) where BomId='{0}' ".FormatEx(bomId));

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            //base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BomId", "产品区分号"));
        }

        protected override void OnInitEvents()
        {
            //base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<bomMeterial> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

        /// <summary>
        /// 导入bomMeterial
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="bomid"></param>
        /// <returns></returns>
        internal bool OnImportBomMeterial(System.Data.DataTable dt, string bomid)
        {
            //定义一个bool变量
            bool result = false;
           
            try
            {

                foreach (System.Data.DataRow item in dt.Rows)
                {
                   
                    //构造bomparent对象
                    EntitySet<bomMeterial> entity = new EntitySet<bomMeterial>();
                    entity.Query("select * from  bomMeterial with(nolock) where 1=0");
                    bomMeterial bom = entity.AddNew();

                    //if (isBomExists(item[3].ToString().Trim(), bomid, bomchildid))
                    //    continue;

                    bom.Iden = IdenGenerator.NewIden("bomMeterial");
                    bom.BomId = bomid;
                    bom.BomChildId = item["零部组件代号"].ToString().Trim();
                    bom.BomChildName = item["零部组件名称"].ToString().Trim();
                    bom.OpDep = item["工段代号"].ToString().Trim();
                    bom.SingleNum = string.IsNullOrEmpty(item["每台件数"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["每台件数"].ToString().Trim());
                    bom.CInvName = item["材料名称"].ToString().Trim();
                    bom.ShopSign = item["牌号状态质量特征及标准号"].ToString().Trim();
                    bom.Invstd = item["精度等级品种规格及标准号"].ToString().Trim();
                    bom.FeedStd = item["坯料尺寸"].ToString().Trim();
                    bom.Weight = string.IsNullOrEmpty(item["质量"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["质量"].ToString().Trim());
                    bom.OneMakeNum = string.IsNullOrEmpty(item["一件坯料可制件数"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["一件坯料可制件数"].ToString().Trim());
                    bom.SingleQty = string.IsNullOrEmpty(item["单台用量"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["单台用量"].ToString().Trim());
                    bom.CComUnitCode = item["单位"].ToString().Trim();
                    bom.ProcQty = string.IsNullOrEmpty(item["工艺定额"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["工艺定额"].ToString().Trim());
                    bom.NetWeight = string.IsNullOrEmpty(item["净质量"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["净质量"].ToString().Trim());
                    bom.MaterialRate = string.IsNullOrEmpty(item["材料利用率"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["材料利用率"].ToString().Trim());
                    bom.Production = item["设备"].ToString().Trim();
                    bom.Mark2 = item["备注2"].ToString().Trim();
                    bom.Proportion = string.IsNullOrEmpty(item["比重"].ToString().Trim()) ? 0 :  Convert.ToDecimal(item["比重"].ToString().Trim());
                    bom.PartNetWeight = string.IsNullOrEmpty(item["零件净质量"].ToString().Trim()) ? 0 : Convert.ToDecimal(item["零件净质量"].ToString().Trim());

                    entity.SaveChanges();

                    
                }
                result = true;


            }
            catch (Exception ex)
            {

                throw ex;

            }
            return result;
        }
    }
}
