
using DevExpress.XtraEditors;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Hardware.Controls.Stopwatch
{
    public sealed class StopwatchConfigManager
    {
        private StopwatchConfigCollection _StopwatchConfigs = null;

        private StopwatchConfigManager() { }

        private static StopwatchConfigManager _current = null;
        private static object lockObj = new object();

        public static StopwatchConfigManager Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObj)
                    {
                        if (_current == null)
                        {
                            _current = new StopwatchConfigManager();
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

            StopwatchConfigCollection configs = null;
            if (File.Exists(configFileName))
            {
                var xml = File.ReadAllText(configFileName);

                try
                {
                    configs = XmlSerializerHelper.Deserialize<StopwatchConfigCollection>(xml);
                }
                catch
                {
                    configs = null;
                }
            }
            if (configs == null)
                configs = new StopwatchConfigCollection();
            this._StopwatchConfigs = configs;
        }

        public void Save()
        {
            var fileName = GetConfigFileName();

            var xml = XmlSerializerHelper.Serialize(this._StopwatchConfigs);
            File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        /// <summary>
        /// 获取配置文件路径
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFileName()
        {
            string startupPath = System.Windows.Forms.Application.StartupPath;
            var fileName = Path.Combine(startupPath, "Config", "StopwatchConfig.xml");
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            return fileName;
        }

        public StopwatchConfig GetConfig(string ConfigFileName)
        {
            return this._StopwatchConfigs.FirstOrDefault(p => p.ConfigName == ConfigFileName);
        }

        public void AddSetting(StopwatchConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("setting");

            var data = GetConfig(config.ConfigName);
            if (data != null)
                this._StopwatchConfigs.Remove(data);

            this._StopwatchConfigs.Add(config);
            this.Save();
        }

        public void ClearConfigs()
        {
            this._StopwatchConfigs.Clear();
            this.Save();
        }

        public void RestoreConfig(StopwatchControl stopwatchControl)
        {
            if (stopwatchControl == null)
                throw new ArgumentNullException("stopwatchControl");

            StopwatchConfig config = StopwatchConfigManager.Current.GetConfig(stopwatchControl.ConfigName);
            if (config != null)
            {
                stopwatchControl.ApplyConfig(config);
            }
            else
            {
                MessageService.ShowError("码表控件没有配置初始化，请先配置初始化。");
            }

        }
    }
}
