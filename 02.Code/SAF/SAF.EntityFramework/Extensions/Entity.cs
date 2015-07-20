using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 通用的查询实体
    /// </summary>
    public class Entity : Entity<Entity>
    {
        protected override void OnInit()
        {
            base.OnInit();
            this.PrimaryKeyName = "Iden";
        }

        public int Iden
        {
            get { return base.GetFieldValue<int>(P => P.Iden, -1); }
            set { base.SetFieldValue(P => P.Iden, value); }
        }

        public string BillNo
        {
            get { return base.GetFieldValue<string>(p => p.BillNo, string.Empty); }
            set { base.SetFieldValue(p => p.BillNo, value); }
        }        
    }
}
