﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using SAF.Framework.ViewModel;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Framework.Entity;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.View
{
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public partial class BusinessView : BaseView, IBusinessView
    {
        public BusinessView()
        {
            InitializeComponent();
        }

        protected new IBusinessViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as IBusinessViewViewModel;
            }
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new BusinessViewViewModel();
        }

        [Browsable(false)]
        [ViewParameter("是否允许添加到收藏夹", ViewParameterControlType.CheckEdit)]
        public bool AllowAddToFavorite
        {
            get
            {
                var result = false;
                Boolean.TryParse(ViewParameters["AllowAddToFavorite"].ToStringEx(), out result);
                return result;
            }
            set
            {
                ViewParameters["AllowAddToFavorite"] = value;
            }
        }

        protected virtual void OnAddMenuToFavorite()
        {
            if (!AllowAddToFavorite) return;

            var es = new EntitySet<sysMyFavoriteMenu>();
            if (!es.TableIsExists()) return;

            es.Query("SELECT TOP 1 * FROM dbo.sysMyFavoriteMenu WITH(NOLOCK) WHERE UserId=:UserId and MenuId=:MenuId", Session.UserInfo.UserId, this.UniqueId);
            if (es.Count <= 0)
            {
                var obj = es.AddNew();
                obj.Iden = IdenGenerator.NewIden(obj.TableName);
                obj.MenuId = Convert.ToInt32(this.UniqueId);
                obj.UserId = Session.UserInfo.UserId;
                obj.RowNumber = 10000;
                es.SaveChanges();
            }

            MessageService.ShowMessage("菜单已经收藏至我的工作台.");

            var shell = ApplicationService.Current.MainForm as IShell;
            if (shell != null)
                shell.RefreshFavorite();

        }
    }
}
