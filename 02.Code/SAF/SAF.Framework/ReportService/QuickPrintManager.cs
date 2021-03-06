﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation.ComponentModel;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;
using System.Xml.Serialization;

namespace SAF.Framework
{
    public class QuickPrintManager
    {
        private static QuickPrintManager _current = null;
        private static object lockObj = new object();

        public static QuickPrintManager Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObj)
                    {
                        if (_current == null)
                        {
                            _current = new QuickPrintManager();
                            _current.LoadConfig();
                        }
                    }
                }
                return _current;
            }
        }

        private string ConfigFileName
        {
            get
            {
                return Path.Combine(ApplicationService.Current.ConfigFilePath, "QuickPrintConfig.xml");
            }
        }

        private void LoadConfig()
        {
            if (File.Exists(ConfigFileName))
            {
                var xml = File.ReadAllText(ConfigFileName);
                this.QuickPrintConfig = XmlSerializerHelper.Deserialize<QuickPrintCollection>(xml);
            }

            if (this.QuickPrintConfig == null)
                this.QuickPrintConfig = new QuickPrintCollection();
        }

        public void SaveConfig()
        {
            var xml = XmlSerializerHelper.Serialize(this.QuickPrintConfig);
            File.WriteAllText(ConfigFileName, xml, Encoding.UTF8);
        }

        private QuickPrintCollection QuickPrintConfig { get; set; }

        private QuickPrintManager()
        {
        }

        public QuickPrintItem GetQuickPrintItem(object UniqueId, int reportId)
        {
            return this.QuickPrintConfig.FirstOrDefault(p => p.MenuId.ToString() == UniqueId.ToString() && p.ReportId == reportId);
        }

        public void AddConfig(QuickPrintItem item)
        {
            if (item == null || item.ReportId <= 0 || item.PrinterName.IsEmpty())
                throw new Exception("快速打印配置不正确，请检查。");
            var tempConfig = this.QuickPrintConfig.FirstOrDefault(p => p.ReportId == item.ReportId && p.MenuId == item.MenuId);
            if (tempConfig != null)
                tempConfig.PrinterName = item.PrinterName;
            else
                this.QuickPrintConfig.Add(item);
        }

        public void RemoveConfig(object menuId, int reportId)
        {
            var config = this.QuickPrintConfig.FirstOrDefault(p => p.ReportId == reportId && p.MenuId == menuId);
            if (config != null)
                this.QuickPrintConfig.Remove(config);
        }
    }

    [XmlRoot("QuickPrintItem")]
    public class QuickPrintItem
    {
        public object MenuId { get; set; }
        public int ReportId { get; set; }
        public string PrinterName { get; set; }
    }

    [XmlRoot("QuickPrintCollection")]
    public class QuickPrintCollection : Collection<QuickPrintItem>
    {

    }
}
