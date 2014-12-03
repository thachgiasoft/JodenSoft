using System;
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
using SAF.Framework.Entities;
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

        protected void AddMenuToFavorite()
        {
            var query = new EntitySet<sysMyFavoriteMenu>();
            query.Query("SELECT TOP 1 * FROM dbo.sysMyFavoriteMenu WITH(NOLOCK) WHERE UserId=:UserId and MenuId=:MenuId", Session.Current.UserId, this.UniqueId);
            if (query.Count <= 0)
            {
                var obj = query.AddNew();
                obj.Iden = IdenGenerator.NewIden(obj.DbTableName);
                obj.MenuId = this.UniqueId;
                obj.UserId = Session.Current.UserId;
                obj.RowNumber = 10000;
                query.SaveChanges();
            }

            MessageService.ShowMessage("菜单已经收藏至我的工作台.");
        }
    }
}
