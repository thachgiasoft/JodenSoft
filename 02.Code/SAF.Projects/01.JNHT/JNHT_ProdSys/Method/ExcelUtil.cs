using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JNHT_ProdSys.Method
{
    public static class ExcelUtil
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="fileName">Excel文件名</param>
        /// <returns></returns>
        private static string GetConnectionString(string fileName)
        {
            string strConn = string.Empty;
            FileInfo file = new FileInfo(fileName);
            if (!file.Exists) { throw new Exception("文件不存在"); }
            string extension = file.Extension;
            switch (extension.ToLower())
            {
                case ".xls":
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }

            return strConn;
        }
        /// <summary>
        /// 获取Excel文件
        /// </summary>
        /// <returns></returns>
        public static string GetExcelFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择 Excel 工作薄...";
                openFileDialog.Filter = "Excel 工作薄(*.xlsx)|*.xlsx|Excel 97-2003 工作薄(*.xls)|*.xls";
                openFileDialog.CheckFileExists = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DefaultExt = "xlsx";
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #region SheetNameSelector
        /// <summary>
        /// 工作表选择界面
        /// </summary>
        internal class SheetNameSelector : Form
        {
            private Label lblName = new Label();
            private ComboBox cbxSheetNames = new ComboBox();
            private Button btnOK = new Button();
            private Button btnCancel = new Button();
            private Label lblSplit = new Label();

            internal SheetNameSelector(IEnumerable<string> sheetNames)
            {
                this.ShowInTaskbar = false;
                this.MinimizeBox = false;
                this.MaximizeBox = false;
                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnCancel;
                this.SizeGripStyle = SizeGripStyle.Hide;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Width = 450;
                this.Height = 150;
                this.MinimumSize = new Size(450, 150);
                this.MaximumSize = new Size(450, 150);
                this.Text = "选择工作表...";

                this.Controls.Add(btnOK);
                this.Controls.Add(btnCancel);
                this.Controls.Add(lblSplit);
                this.Controls.Add(lblName);
                this.Controls.Add(cbxSheetNames);

                this.lblName.Text = "工作表:";
                this.lblName.Left = 10;
                this.lblName.Top = 22;
                this.lblName.Width = 60;

                this.cbxSheetNames.Left = 70;
                this.cbxSheetNames.Top = 20;
                this.cbxSheetNames.Width = 350;
                this.cbxSheetNames.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (var item in sheetNames)
                {
                    this.cbxSheetNames.Items.Add(item);
                }
                this.cbxSheetNames.Items.Insert(0, "--请选择--");
                this.cbxSheetNames.SelectedIndex = 0;

                lblSplit.Text = string.Empty;
                lblSplit.BorderStyle = BorderStyle.Fixed3D;
                lblSplit.Left = 2;
                lblSplit.Top = 65;
                lblSplit.Height = 2;
                lblSplit.Width = 430;

                btnOK.Text = "确定(&E)";
                btnOK.Top = 75;
                btnOK.Left = 265;
                btnOK.Width = 75;
                btnOK.Height = 23;
                btnOK.Click += (sender, args) =>
                {
                    if (this.cbxSheetNames.SelectedIndex == 0)
                    {
                        MessageBox.Show("请选择工作表.", "出错了!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                };

                btnCancel.Text = "取消(&C)";
                btnCancel.Top = 75;
                btnCancel.Left = 345;
                btnCancel.Width = 75;
                btnCancel.Height = 23;
                btnCancel.DialogResult = DialogResult.Cancel;

            }

            public static string SelectExcelSheet(IEnumerable<string> sheetNames)
            {
                using (var selector = new SheetNameSelector(sheetNames))
                {
                    if (selector.ShowDialog() == DialogResult.OK)
                    {
                        if (selector.cbxSheetNames.SelectedIndex != 0)
                            return selector.cbxSheetNames.Text;
                    }
                    return string.Empty;
                }
            }
        }

        #endregion

        /// <summary>
        /// 获取工作表名称
        /// </summary>
        /// <param name="fileName">Excel文件名</param>
        /// <returns></returns>
        public static string GetSheetName(string fileName)
        {
            var list = GetExcelSheetNames(fileName);
            return SheetNameSelector.SelectExcelSheet(list);
        }
        /// <summary>
        /// 获取Excel中所有的工作表名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetExcelSheetNames(string fileName)
        {
            string strConn = GetConnectionString(fileName);
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

                if (dtSheetName.Rows.Count <= 0)
                    throw new Exception(string.Format("文件\"{0}\"中没有有效的工作表.", fileName));

                //包含excel中表名的字符串数组 
                List<string> sheetNames = new List<string>();
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    string sheetName = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                    if (!string.IsNullOrWhiteSpace(sheetName))
                        sheetNames.Add(sheetName);
                }
                return sheetNames;
            }
        }
        /// <summary>
        /// 导入到DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable ExcelToDataTable()
        {
            string fileName = GetExcelFile();
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            string strConn = GetConnectionString(fileName);

            string sheetName = GetSheetName(fileName);
            if (string.IsNullOrWhiteSpace(sheetName)) return null;

            //链接Excel
            using (OleDbConnection cnnxls = new OleDbConnection(strConn))
            {
                OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}]", sheetName), cnnxls);
                DataSet ds = new DataSet();
                //将Excel里面有表内容装载到内存表中！
                oda.Fill(ds);
                return ds.Tables[0];
            }
        }
    }


}
