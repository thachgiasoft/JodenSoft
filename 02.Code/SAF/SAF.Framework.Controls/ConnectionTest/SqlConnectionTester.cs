using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.Controls
{
    public class SqlConnectionTester : IConnectionTester
    {
        private bool _ConnectSuccess = false;
        private int _MinTimes = 1000;
        private int _MaxTimes = 5000;

        private string _ConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }
        }

        public SqlConnectionTester(string connectionString)
        {
            if (connectionString.IsEmpty())
                throw new ArgumentNullException("connectionString");
            this._ConnectionString = connectionString;
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            Thread makeConnectionThread = new Thread(TestConnection);
            makeConnectionThread.IsBackground = true;
            makeConnectionThread.Priority = ThreadPriority.Highest;
            makeConnectionThread.Start();

            int sleepTimes = 0;

            while (!_ConnectSuccess || sleepTimes < _MinTimes)
            {
                Application.DoEvents();
                Thread.Sleep(50);
                sleepTimes += 50;
                if (sleepTimes > _MaxTimes)
                {
                    makeConnectionThread.Abort();
                    return false;
                }
            }
            return true;
        }

        private void TestConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = _ConnectionString;
                sqlConnection.Open();
                sqlConnection.Close();
                _ConnectSuccess = true;
            }
            catch
            {
                sqlConnection.Close();
                _ConnectSuccess = false;
            }
        }
    }
}
