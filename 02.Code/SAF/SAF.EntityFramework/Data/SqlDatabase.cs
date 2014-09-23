using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public class SqlDatabase : Database
    {
        public SqlDatabase(string connectionString)
            : base(connectionString, SqlClientFactory.Instance)
        { }

        protected char ParameterToken
        {
            get
            {
                return '@';
            }
        }

        protected override string BuildParameterName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            name = name.Trim();
            if (name[0] != this.ParameterToken)
            {
                return name.Insert(0, new string(this.ParameterToken, 1));
            }
            return name;
        }

        protected override int UserParametersStartIndex()
        {
            return 0;
        }

    }
}
