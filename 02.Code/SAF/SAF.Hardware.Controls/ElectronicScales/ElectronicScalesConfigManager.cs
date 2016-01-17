
using DevExpress.XtraEditors;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Hardware.Controls.ElectronicScales
{
    public sealed class ElectronicScalesConfigManager
    {
        private ElectronicScalesConfigCollection _ElectronicScalesConfigs = null;

        private ElectronicScalesConfigManager() { }

        private static ElectronicScalesConfigManager _current = null;
        private static object lockObj = new object();

        public static ElectronicScalesConfigManager Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObj)
                    {
                        if (_current == null)
                        {
                            _current = new ElectronicScalesConfigManager();
                            _current.Load();
                        }
                    }
                }
                return _current;
            }
        }

        private void Load()
        {
            var configFileName = GetConfigFileName();

            ElectronicScalesConfigCollection configs = null;
            if (File.Exists(configFileName))
            {
                var xml = File.ReadAllText(configFileName);

                try
                {
                    configs = XmlSerializerHelper.Deserialize<ElectronicScalesConfigCollection>(xml);
                }
                catch
                {
                    configs = null;
                }
            }
            if (configs == null)
                configs = new ElectronicScalesConfigCollection();
            this._ElectronicScalesConfigs = configs;
        }

        public void Save()
        {
            var fileName = GetConfigFileName();

            var xml = XmlSerializerHelper.Serialize(this._ElectronicScalesConfigs);
            File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        /// <summary>
        /// 获取配置文件路径
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFileName()
        {
            string startupPath = System.Windows.Forms.Application.StartupPath;
            var fileName = Path.Combine(startupPath, "Config", "ElectronicScalesConfig.xml");
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            return fileName;
        }

        public ElectronicScalesConfig GetConfig(string configName)
        {
            return this._ElectronicScalesConfigs.FirstOrDefault(p => p.ConfigName == configName);
        }

        public void AddSetting(ElectronicScalesConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("setting");

            var data = GetConfig(config.ConfigName);
            if (data != null)
                this._ElectronicScalesConfigs.Remove(data);

            this._ElectronicScalesConfigs.Add(config);
            this.Save();
        }

        public void ClearConfigs()
        {
            this._ElectronicScalesConfigs.Clear();
            this.Save();
        }

        public void RestoreConfig(ElectronicScalesControl electronicScalesControl)
        {
            if (electronicScalesControl == null)
                throw new ArgumentNullException("ElectronicScalesControl");

            ElectronicScalesConfig config = ElectronicScalesConfigManager.Current.GetConfig(electronicScalesControl.ConfigName);
            if (config != null)
            {
                electronicScalesControl.ApplyConfig(config);
            }
            else
            {
                MessageService.ShowError("电子称控件没有配置初始化，请先配置初始化。");
            }

        }
    }
}
