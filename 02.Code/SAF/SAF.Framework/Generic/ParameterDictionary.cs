using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    public class ParameterDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        private Dictionary<string, object> _params = new Dictionary<string, object>();

        public ParameterDictionary()
        {

        }

        public ParameterDictionary(IEntityBase entity)
        {
            Copy(entity);
        }

        public ParameterDictionary(ParameterDictionary paramDic)
        {
            Copy(paramDic);
        }

        public void Copy(IEntityBase entity)
        {
            foreach (DataColumn item in entity.DataRowView.DataView.Table.Columns)
            {
                this[item.ColumnName] = entity.GetFieldValue<object>(item.ColumnName);
            }
        }

        public void Copy(ParameterDictionary paramDic)
        {
            foreach (var item in paramDic)
            {
                this[item.Key] = item.Value;
            }
        }

        public object this[string key]
        {
            get
            {
                if (this._params.ContainsKey(key))
                    return this._params[key];
                return null;
            }
            set
            {
                if (this._params.ContainsKey(key))
                    this._params[key] = value;
                else
                    this._params.Add(key, value);
            }
        }

        public void Add(string key, object value)
        {
            this._params.Add(key, value);
        }

        public bool Remove(string key)
        {
            return this._params.Remove(key);
        }

        public int Count
        {
            get
            {
                return this._params.Count;
            }
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this._params.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
