using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.Security;
using System.Data;
using myPortal.BLL;
using myPortal.Model;
using myPortal.Foundation.Extensions;
using myPortal.Foundation;
using System.Configuration;

namespace myPortal.Web
{
    /// <summary>
    /// Page�Ļ���
    /// </summary>
    public class PageBase : Page
    {
        protected bool hasError = false;
        protected string errorMsg = string.Empty;
        private string _sUserName = string.Empty;
        private string _sUserNo = string.Empty;
        private int _iUserId = int.MinValue;
        private string _sEmail = string.Empty;

        protected int WorkspaceHeight
        {
            get
            {
                int height = 400;
                if (Session["WorkspaceHeight"] != null)
                {
                    int.TryParse(Session["WorkspaceHeight"].ToStringEx(), out height);
                    if (height <= 0)
                        height = 400;
                    else
                        height = height - 40;
                }
                return height;
            }
        }
        /// <summary>
        /// �жϵ�ǰҳ���Ƿ����޸Ĳ���
        /// <para>"m".Equals(Request["Action"]);</para>
        /// </summary>
        protected bool IsModifyAction
        {
            get
            {
                return "m".Equals(Request["Action"]);
            }
        }

        private int _iOrgId = int.MinValue;
        /// <summary>
        /// �û�����
        /// </summary>
        protected string sEmail
        {
            get
            {
                return _sEmail;
            }
        }
        /// <summary>
        /// ��ǰ�û�����
        /// </summary>
        protected string sUserName
        {
            get
            {
                return _sUserName;
            }
        }
        /// <summary>
        /// ��ǰ�û�����
        /// </summary>
        protected string sUserNo
        {
            get
            {
                return _sUserNo;
            }
        }
        /// <summary>
        /// ��ǰ�û�iIden
        /// </summary>
        protected int iUserID
        {
            get
            {
                return _iUserId;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
#if !DEBUG
            this.Error += new System.EventHandler(PageBase_Error);
#endif
        }

        //������
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = "<link rel=\"stylesheet\" href=\"../Css/common.css\" type=\"text/css\" />";
            errMsg += @"<div class='w_p100'>
                <div class='err_tips'>
                <h1>ϵͳ����</h1>
                <hr/>ϵͳ���������������Ա��ϵ��<br/>�����ַ��" + Request.Url.ToString() +
                @"<br/> ������Ϣ��" + currentError.Message.ToString() +
                "<hr/><b>Stack Trace:</b><br/>" + currentError.ToString() +
                @"</div>
                </div>";
            //<div class='f_r m_10'>
            //        <input type='button' onclick='javascript:history.go(-1);' value='����' class='n_btn w_60' /> 
            //      </div>
            Response.Clear();
            Response.Write(errMsg);
            Server.ClearError();
        }
        /// <summary>
        /// ҳ���ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Page_Init(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                saUserInfo user = null;
                if (int.TryParse(User.Identity.Name, out this._iUserId))
                {
                    user = saUser.Current.GetUser(this._iUserId);
                }

                if (user == null)
                {
                    Response.Redirect("Default.aspx");
                }

                this._sUserNo = user.sUserNo;
                this._sUserName = user.sUserName;
                this._sEmail = user.sEmail;
            }
        }

        /// <summary>
        /// ҳ��
        /// </summary>
        public int PageIndex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["PageIndex"]))
                    return 1;
                else
                {
                    int _PageIndex = 0;
                    if (int.TryParse(Request.QueryString["PageIndex"], out _PageIndex))
                        return _PageIndex;
                    else
                        return 1;
                }
            }
        }
    }
}
