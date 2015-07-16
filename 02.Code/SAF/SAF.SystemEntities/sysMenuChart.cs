using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntities
{
    public class sysMenuChart : Entity<sysMenuChart>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sysMenuChart";
            this.IdenGroup = "sysMenuChart";
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

        public string Remark
        {
            get { return base.GetFieldValue<string>(P => P.Remark); }
            set { base.SetFieldValue(P => P.Remark, value); }
        }

        public byte[] FileData
        {
            get { return base.GetFieldValue<byte[]>(P => P.FileData); }
            set { base.SetFieldValue(P => P.FileData, value); }
        }


      
    }
}
