using SAF.Foundation.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    public static class ApplicationConfig
    {
        public static string GetConnectionString(string name)
        {
            if (name.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.GetConnectionString:name");

            if (ConfigurationManager.ConnectionStrings[name] != null)
            {
                try
                {
                    return AESHelper.Decrypt(ConfigurationManager.ConnectionStrings[name].ConnectionString);
                }
                catch
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        public static void SetConnectionString(string name, string connectionString, string providerName)
        {
            if (name.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.SetConnectionString:name");

            if (connectionString.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.SetConnectionString:connectionString");

            if (providerName.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.SetConnectionString:providerName");

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (cfa.ConnectionStrings.ConnectionStrings[name] == null)
            {
                cfa.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, AESHelper.Encrypt(connectionString), providerName));
            }
            else
            {
                cfa.ConnectionStrings.ConnectionStrings[name].ConnectionString = AESHelper.Encrypt(connectionString);
                cfa.ConnectionStrings.ConnectionStrings[name].ProviderName = providerName;
            }
            cfa.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void RemoveConnectionString(string name)
        {
            if (name.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.RemoveConnectionString:name");

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (cfa.ConnectionStrings.ConnectionStrings[name] != null)
            {
                cfa.ConnectionStrings.ConnectionStrings.Remove(name);
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        public static string GetAppSetting(string key)
        {
            if (key.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.GetAppSetting:key");

            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            return string.Empty;
        }

        public static void SetAppSetting(string key, string value)
        {
            if (key.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.SetAppSetting:key");

            if (value.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.SetAppSetting:value");


            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void RemoveAppSetting(string key)
        {
            if (key.IsEmpty())
                throw new ArgumentNullException("ApplicationConfigHelper.RemoveAppSetting:key");

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                config.AppSettings.Settings.Remove(key);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
