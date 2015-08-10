using DevExpress.LookAndFeel;
using DevExpress.Skins;
using SAF.EntityFramework;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using SAF.Framework.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SAF.Framework.ComponentModel
{
    [Serializable]
    public sealed class AppConfig
    {
        public string ThemeName { get; set; }
        public bool ShowWelcomePage { get; set; }
        public bool ShowNavigationPage { get; set; }
        public bool ShowWorkSpace { get; set; }

        /// <summary>
        /// 从数据库中加载用户的应用程序配置信息
        /// </summary>
        public void Load()
        {
            var es = new EntitySet<sysAppConfig>();
            es.Query("select * from sysAppConfig with(nolock) where UserId=:UserId", Session.UserInfo.UserId);
            if (es.Count > 0)
            {
                var str = es.CurrentEntity.GetFieldValue<string>("AppConfig");
                var obj = XmlSerializerHelper.Deserialize<AppConfig>(str);
                if (obj != null)
                {
                    this.ThemeName = obj.ThemeName;
                    this.ShowWelcomePage = obj.ShowWelcomePage;
                    this.ShowNavigationPage = obj.ShowNavigationPage;
                    this.ShowWorkSpace = obj.ShowWorkSpace;
                }
            }
        }

        public void Save()
        {
            var es = new EntitySet<sysAppConfig>();
            es.Query("select * from sysAppConfig with(nolock) where UserId=:UserId", Session.UserInfo.UserId);
            sysAppConfig entity = null;
            if (es.Count <= 0)
            {
                entity = es.AddNew();
                entity.Iden = IdenGenerator.NewIden(entity.TableName);
            }
            else
                entity = es.First();

            entity.UserId = Session.UserInfo.UserId;
            entity.AppConfig = XmlSerializerHelper.Serialize<AppConfig>(this);
            es.SaveChanges();
        }
        /// <summary>
        /// 设置皮肤
        /// </summary>
        public void SetTheme()
        {
            UserLookAndFeel.Default.SetSkinStyle(ThemeName);
            ProgressService.SkinName = ThemeName;
        }

        #region 单例

        private AppConfig()
        {
            this.ThemeName = "Office 2013";
            this.ShowWelcomePage = false;
            this.ShowNavigationPage = false;
            this.ShowWorkSpace = false;
        }

        private static AppConfig _current = null;
        private static object _obj = new object();

        public static AppConfig Current
        {
            get
            {
                if (_current == null)
                {
                    lock (_obj)
                    {
                        if (_current == null)
                            _current = new AppConfig();
                    }
                }
                return _current;
            }
        }

        #endregion

    }
}
