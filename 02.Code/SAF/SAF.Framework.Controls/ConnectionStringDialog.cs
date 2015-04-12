using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;
using System.Threading;

namespace SAF.Framework.Controls
{
    public partial class ConnectionStringDialog : XtraForm
    {
        private object[] _servers;
        private object[] _databases;
        private Thread _serverEnumerationThread;
        private Thread _databaseEnumerationThread;

        public ConnectionStringDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;

            this.chkWindows.Checked = true;
            this.txtUserId.Enabled = false;
            this.txtPassword.Enabled = false;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (ConnectionParamHasError())
                return;
            this.TestLocalSqlConnection(this.ConnectionString);
        }

        private void TestLocalSqlConnection(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandTimeout = 15;
                    cmd.CommandText = "select getdate()";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteScalar();
                    XtraMessageBox.Show(this, "连接成功!", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(this, ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = cbxServer.EditValue.ToStringEx().Trim();
                sb.InitialCatalog = cbxDatabase.EditValue.ToStringEx().Trim();

                if (this.chkSqlServer.Checked)
                {
                    sb.UserID = txtUserId.EditValue.ToStringEx().Trim();
                    sb.Password = txtPassword.EditValue.ToStringEx().Trim();
                    sb.PersistSecurityInfo = true;
                }
                else
                {
                    sb.IntegratedSecurity = true;
                }

                return sb.ConnectionString;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) return;
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.ConnectionString = value;

                this.cbxServer.EditValue = sb.DataSource;

                if (sb.IntegratedSecurity)
                {
                    this.chkWindows.Checked = true;
                }
                else
                {
                    this.chkSqlServer.Checked = true;
                    this.txtUserId.EditValue = sb.UserID;
                    this.txtPassword.EditValue = sb.Password;
                }

                this.cbxDatabase.EditValue = sb.InitialCatalog;
            }
        }

        private void EnumerateDatabases()
        {
            DataTable dataTable = null;
            IDataReader reader = null;
            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = cbxServer.EditValue.ToStringEx().Trim();
                sb.InitialCatalog = "Master";
                sb.ConnectTimeout = 10;
                sb.Pooling = false;
                sb.PersistSecurityInfo = true;

                if (this.chkSqlServer.Checked)
                {
                    sb.IntegratedSecurity = false;
                    sb.UserID = txtUserId.EditValue.ToStringEx().Trim();
                    sb.Password = txtPassword.EditValue.ToStringEx().Trim();
                }
                else
                {
                    sb.IntegratedSecurity = true;
                }

                using (SqlConnection connection = new SqlConnection(sb.ConnectionString))
                {
                    connection.Open();
                    // Create a command to check if the database is on SQL AZure.
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT CASE WHEN SERVERPROPERTY(N'EDITION') = 'SQL Data Services' OR SERVERPROPERTY(N'EDITION') = 'SQL Azure' THEN 1 ELSE 0 END";

                        // SQL AZure doesn't support HAS_DBACCESS at this moment.
                        // Change the command text to get database names accordingly
                        if ((Int32)(command.ExecuteScalar()) == 1)
                        {
                            command.CommandText = "SELECT name FROM master.dbo.sysdatabases ORDER BY name";
                        }
                        else
                        {
                            command.CommandText = "SELECT name FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1 ORDER BY name";
                        }

                        // Execute the command
                        using (reader = command.ExecuteReader())
                        {
                            // Read into the data table
                            dataTable = new DataTable();
                            dataTable.Locale = System.Globalization.CultureInfo.CurrentCulture;
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch
            {
                dataTable = new DataTable();
                dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            }
            // Create the object array of database names
            _databases = new object[dataTable.Rows.Count];
            for (int i = 0; i < _databases.Length; i++)
            {
                _databases[i] = dataTable.Rows[i]["name"];
            }

            // Populate the database combo box items (must occur on the UI thread)
            if (this.IsHandleCreated)
                BeginInvoke(new ThreadStart(PopulateDatabaseComboBox));
            else
                PopulateDatabaseComboBox();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ConnectionParamHasError())
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkWindows.Checked)
            {
                this.txtUserId.EditValue = string.Empty;
                this.txtUserId.Enabled = false;

                this.txtPassword.EditValue = string.Empty;
                this.txtPassword.Enabled = false;
            }
            else if (this.chkSqlServer.Checked)
            {
                this.txtUserId.Enabled = true;
                this.txtPassword.Enabled = true;
            }

            cbxDatabase.Properties.Items.Clear();
            cbxDatabase.EditValue = string.Empty;
        }

        private bool ConnectionParamHasError()
        {
            if (this.cbxServer.EditValue.ToStringEx().IsEmpty())
            {
                XtraMessageBox.Show(this, "请输入数据库服务器名称或IP!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxServer.Focus();
                return true;
            }

            if (this.chkSqlServer.Checked)
            {
                if (this.txtUserId.EditValue.ToStringEx().IsEmpty())
                {
                    XtraMessageBox.Show(this, "请输入用户名!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUserId.Focus();
                    return true;
                }
                if (this.txtPassword.EditValue.ToStringEx().IsEmpty())
                {
                    XtraMessageBox.Show(this, "请输入密码!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Focus();
                    return true;
                }
            }

            if (this.cbxDatabase.EditValue.ToStringEx().IsEmpty())
            {
                XtraMessageBox.Show(this, "请输入或选择一个数据库!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxDatabase.Focus();
                return true;
            }

            return false;
        }

        private void cbxDatabase_QueryPopUp(object sender, CancelEventArgs e)
        {
            EnumerateDatabases(sender, e);
        }

        private void SetDatabase(object sender, System.EventArgs e)
        {
            if (cbxDatabase.Properties.Items.Count == 0 && _databaseEnumerationThread == null)
            {
                // Start an enumeration of databases
                _databaseEnumerationThread = new Thread(new ThreadStart(EnumerateDatabases));
                _databaseEnumerationThread.Start();
            }
        }

        private void EnumerateDatabases(object sender, System.EventArgs e)
        {
            if (cbxDatabase.Properties.Items.Count == 0)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (_databaseEnumerationThread == null ||
                        _databaseEnumerationThread.ThreadState == ThreadState.Stopped)
                    {
                        EnumerateDatabases();
                    }
                    else if (_databaseEnumerationThread.ThreadState == ThreadState.Running)
                    {
                        // Wait for the asynchronous enumeration to finish
                        _databaseEnumerationThread.Join();

                        // Populate the combo box now, rather than waiting for
                        // the asynchronous call to be marshaled back to the UI
                        // thread
                        PopulateDatabaseComboBox();
                    }
                }
                finally
                {
                    Cursor.Current = currentCursor;
                }
            }
        }

        private void PopulateDatabaseComboBox()
        {
            if (cbxDatabase.Properties.Items.Count == 0)
            {
                if (_databases.Length > 0)
                {
                    cbxDatabase.Properties.Items.AddRange(_databases);
                }
            }
            _databaseEnumerationThread = null;
        }

        private void SetServer(object sender, EventArgs e)
        {
            if (cbxServer.Properties.Items.Count == 0 && _serverEnumerationThread == null)
            {
                // Start an enumeration of servers
                _serverEnumerationThread = new Thread(new ThreadStart(EnumerateServers));
                _serverEnumerationThread.Start();
            }

            SetDatabaseGroupBoxStatus(sender, e);
            cbxDatabase.Properties.Items.Clear(); // a server change requires a refresh here
        }

        private void SetDatabaseGroupBoxStatus(object sender, System.EventArgs e)
        {
            if (cbxServer.Text.Trim().Length > 0 &&
                (chkWindows.Checked ||
                txtUserId.Text.Trim().Length > 0))
            {
                groupDatabase.Enabled = true;
            }
            else
            {
                groupDatabase.Enabled = false;
            }
        }

        private void btnRefreshServer_Click(object sender, EventArgs e)
        {
            this.cbxServer.Properties.Items.Clear();
            EnumerateServers(sender, e);
        }

        private void EnumerateServers(object sender, EventArgs e)
        {
            if (cbxServer.Properties.Items.Count == 0)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (_serverEnumerationThread == null ||
                        _serverEnumerationThread.ThreadState == ThreadState.Stopped)
                    {
                        EnumerateServers();
                    }
                    else if (_serverEnumerationThread.ThreadState == ThreadState.Running)
                    {
                        // Wait for the asynchronous enumeration to finish
                        _serverEnumerationThread.Join();

                        // Populate the combo box now, rather than waiting for
                        // the asynchronous call to be marshaled back to the UI
                        // thread
                        PopulateServerComboBox();
                    }
                }
                finally
                {
                    Cursor.Current = currentCursor;
                }
            }
        }

        private void EnumerateServers()
        {
            // Perform the enumeration
            DataTable dataTable = null;
            try
            {
                dataTable = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            }
            catch
            {
                dataTable = new DataTable();
                dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            }

            // Create the object array of server names (with instances appended)
            _servers = new object[dataTable.Rows.Count];
            for (int i = 0; i < _servers.Length; i++)
            {
                string name = dataTable.Rows[i]["ServerName"].ToString();
                string instance = dataTable.Rows[i]["InstanceName"].ToString();
                if (instance.Length == 0)
                {
                    _servers[i] = name;
                }
                else
                {
                    _servers[i] = name + "\\" + instance;
                }
            }

            // Sort the list
            Array.Sort(_servers);

            // Populate the server combo box items (must occur on the UI thread)
            if (this.IsHandleCreated)
                BeginInvoke(new ThreadStart(PopulateServerComboBox));
            else
                PopulateServerComboBox();
        }

        private void PopulateServerComboBox()
        {
            if (cbxServer.Properties.Items.Count == 0)
            {
                if (_servers.Length > 0)
                {
                    cbxServer.Properties.Items.AddRange(_servers);
                }
            }
        }

        private void TrimControlText(object sender, System.EventArgs e)
        {
            Control c = sender as Control;
            c.Text = c.Text.Trim();
        }

        private void HandleComboBoxDownKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (sender == this.cbxServer)
                {
                    EnumerateServers(sender, e);
                }
                if (sender == this.cbxDatabase)
                {
                    EnumerateDatabases(sender, e);
                }
            }
        }

        private void cbxServer_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.EnumerateServers(sender, e);
        }
    }
}
