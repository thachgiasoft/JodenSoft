using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.SystemEntity
{
    /// <summary>
    /// 系统表视图
    /// </summary>
    public class Tables : Entity<Tables>
    {
        protected override void OnInit()
        {
            base.OnInit();

            this.TableName = "sys.tables";
            this.IdenGroup = "sys.tables";
            this.PrimaryKeyName = "Name";
        }

        public string Name
        {
            get { return base.GetFieldValue<string>(P => P.Name); }
            set { base.SetFieldValue(P => P.Name, value); }
        }

    }
}
