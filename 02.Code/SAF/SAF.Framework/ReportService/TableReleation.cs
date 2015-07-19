using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework
{
    public class TableReleation
    {
        public string PrimaryTableName { get; set; }
        public string PrimaryTableKeyName { get; set; }

        public string ForeignTableName { get; set; }
        public string ForeignTableKeyName { get; set; }

        public int FieldCount
        {
            get
            {
                int i = 0;
                if (!this.PrimaryTableName.IsEmpty())
                    i++;

                if (!this.PrimaryTableKeyName.IsEmpty() && i > 0)
                    i++;

                if (!this.ForeignTableName.IsEmpty() && i > 0)
                    i++;

                if (!this.ForeignTableKeyName.IsEmpty() && i > 0)
                    i++;

                return i;
            }
        }

        public void Validate()
        {
            if (this.FieldCount != 1 && this.FieldCount != 4)
                throw new Exception("数据集关系输入错误.");
        }

        public TableReleation(string sReleation)
        {
            //a 或者 b.Iden=a.Iden
            var tables = sReleation.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (tables.Length > 0)
                this.PrimaryTableName = tables[0].Trim();
            if (tables.Length > 1)
                this.ForeignTableName = tables[1].Trim();

            if (!this.PrimaryTableName.IsEmpty())
            {
                var items = this.PrimaryTableName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length > 1)
                {
                    this.PrimaryTableName = items[0].Trim();
                    this.PrimaryTableKeyName = items[1].Trim();
                }
            }
            if (!this.ForeignTableName.IsEmpty())
            {
                var items = this.ForeignTableName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length > 1)
                {
                    this.ForeignTableName = items[0].Trim();
                    this.ForeignTableKeyName = items[1].Trim();
                }
            }
        }
    }
}
