using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using JDM.Framework.ServiceModel;
using SAF.Foundation;
using JDM.Entity;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using JDM.Framework.Security;

namespace JDM.SystemModule
{
    public class RegistrationInfoViewViewModel : SingleViewViewModel<sysRegistrationInfo, sysRegistrationInfo>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = @"SELECT A.* ,CustomerName=B.Name
FROM dbo.sysRegistrationInfo a WITH(NOLOCK) 
JOIN dbo.sysCustomer B WITH(NOLOCK) ON A.CustomerId=B.Iden 
WHERE ({0})".FormatEx(sCondition);
            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            string sql = @"
SELECT A.* ,CustomerName=B.Name
FROM dbo.sysRegistrationInfo a WITH(NOLOCK) 
JOIN dbo.sysCustomer B WITH(NOLOCK) ON A.CustomerId=B.Iden
WHERE a.Iden=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("B.Name", "客户名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("A.MachineCode", "机器码"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysRegistrationInfo> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.CustomerId = 0;
            e.CurrentEntity.SetFieldValue("CustomerName", string.Empty);
            e.CurrentEntity.MachineCode = string.Empty;
            e.CurrentEntity.MachineName = string.Empty;
            e.CurrentEntity.Version = ApplicationVersion.Professional;
            e.CurrentEntity.OnLineLimit = 1;
            e.CurrentEntity.RegistrationDate = DateTime.Now.Date;
            e.CurrentEntity.ExpiredDate = DateTime.Now.AddDays(180).Date;

            e.CurrentEntity.ActivationResponse = string.Empty;
        }


        protected override bool OnValidateData()
        {
            var result = base.OnValidateData();

            this.MainEntitySet.CurrentEntity.GetFieldValue<string>("CustomerName").CheckNotNullOrEmpty("客户");
            this.MainEntitySet.CurrentEntity.MachineName.CheckNotNullOrEmpty("机器名");
            this.MainEntitySet.CurrentEntity.MachineCode.CheckNotNullOrEmpty("机器码");
            this.MainEntitySet.CurrentEntity.Version.Required(p => p.In(ApplicationVersion.Trial, ApplicationVersion.Professional, ApplicationVersion.Ultimate), "请选择软件版本.");
            this.MainEntitySet.CurrentEntity.OnLineLimit.CheckGreaterThan("在线人数", 0);
            this.MainEntitySet.CurrentEntity.RegistrationDate.Required(p => p != default(DateTime), "请选择注册日期.");
            this.MainEntitySet.CurrentEntity.ExpiredDate.Required(p => p != default(DateTime), "请选择到期日期.");

            this.MainEntitySet.CurrentEntity.ExpiredDate.CheckGreaterThan("过期日期", this.MainEntitySet.CurrentEntity.RegistrationDate);

            return result;
        }

        protected override bool OnBeforeSave()
        {
            var result = base.OnBeforeSave();

            var response = new ActivationResponse();
            response.CustomerId = this.MainEntitySet.CurrentEntity.CustomerId;
            response.CustomerName = this.MainEntitySet.CurrentEntity.GetFieldValue<string>("CustomerName");
            response.MachineName = this.MainEntitySet.CurrentEntity.MachineName;
            response.MachineCode = this.MainEntitySet.CurrentEntity.MachineCode;
            response.OnLineLimit = this.MainEntitySet.CurrentEntity.OnLineLimit;
            response.Version = this.MainEntitySet.CurrentEntity.Version;
            response.RegsterationDate = this.MainEntitySet.CurrentEntity.RegistrationDate;
            response.ExpiredDate = this.MainEntitySet.CurrentEntity.ExpiredDate;

            var xml = XmlSerializerHelper.Serialize<ActivationResponse>(response);

            var signXml = RSASignatureHelper.Signature(JDM.Framework.Security.RSAKey.PrivateKey, xml);

            this.MainEntitySet.CurrentEntity.ActivationResponse = signXml;

            return result;
        }

        protected override void OnDelete()
        {
            var curr = this.MainEntitySet.CurrentEntity;
            if (curr == null)
                return;

            this.MainEntitySet.CurrentEntity.IsDeleted = true;
            this.IndexEntitySet.DeleteCurrent();
        }
    }
}
