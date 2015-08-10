using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JNHT_ProdSys.Base
{
    public class person : Entity<person>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.DbTableName = "person";
            this.PrimaryKeyName = "Iden";
        }
  
        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        //TODO:添加其他字段
         public string UserName
        {
            get { return base.GetFieldValue<string>(P => P.UserName); }
            set { base.SetFieldValue(P => P.UserName, value); }
        }
         public string UserFullName
        {
            get { return base.GetFieldValue<string>(P => P.UserFullName); }
            set { base.SetFieldValue(P => P.UserFullName, value); }
        }
         public int OrganizationId
        {
            get { return base.GetFieldValue<int>(P => P.OrganizationId); }
            set { base.SetFieldValue(P => P.OrganizationId, value); }
        }
         public bool IsActive
        {
            get { return base.GetFieldValue<bool>(P => P.IsActive); }
            set { base.SetFieldValue(P => P.IsActive, value); }
        }
         public string Cdefine1
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine1); }
            set { base.SetFieldValue(P => P.Cdefine1, value); }
        }
         public string Cdefine2
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine2); }
            set { base.SetFieldValue(P => P.Cdefine2, value); }
        }
         public string Cdefine3
        {
            get { return base.GetFieldValue<string>(P => P.Cdefine3); }
            set { base.SetFieldValue(P => P.Cdefine3, value); }
        }
    }
}
