using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Management;
using System.Security.Cryptography;
using SAF.Foundation.Security;
using System.Text.RegularExpressions;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 硬件信息
    /// </summary>
    public class MachineInfo
    {
        #region Machine Properties
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName
        {
            get
            {
                return Environment.UserName;
            }
        }
        /// <summary>
        /// 机器用户
        /// </summary>
        public string MachineUser
        {
            get
            {
                return Environment.MachineName;
            }
        }
        private string _ProductCode = string.Empty;
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProductCode
        {
            get
            {
                if (_ProductCode.IsEmpty())
                    _ProductCode = MD5Helper.Hash("{0}-{1}".FormatWith(MachineCode, AssemblyInfoHelper.ProductName));
                return _ProductCode;
            }
        }
        #endregion

        private string _MachineCode = string.Empty;
        public string MachineCode
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_MachineCode))
                    _MachineCode = MD5Helper.Hash(string.Format("[{0}]-[{1}]-[{2}]-[{3}]-[{4}]", MachineName, UUID, ProcessorId, BiosSerialNumber, BaseBoardSerialNumber),true);
                return _MachineCode;
            }
        }

        /// <summary>
        /// 取CPU编号
        /// </summary>
        /// <returns></returns> 
        private string ProcessorId
        {
            get
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_Processor");
                    ManagementObjectCollection moc = mc.GetInstances();
                    string strCpuID = string.Empty;
                    foreach (ManagementObject mo in moc)
                    {
                        strCpuID += mo["ProcessorId"].ToString();
                    }
                    if (string.IsNullOrEmpty(strCpuID)) throw new NullReferenceException("strCpuID");
                    return strCpuID;
                }
                catch
                {
                    return "UnknowCpu";
                }
            }
        }
        /// <summary>
        /// 取主板编号 
        /// </summary>
        /// <returns></returns>
        private string BaseBoardSerialNumber
        {
            get
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                    ManagementObjectCollection moc = mc.GetInstances();
                    string strBaseBoardID = string.Empty;
                    foreach (ManagementObject mo in moc)
                    {
                        strBaseBoardID += mo["SerialNumber"].ToString();
                    }
                    if (string.IsNullOrEmpty(strBaseBoardID)) throw new NullReferenceException("strBaseBoardID");
                    return strBaseBoardID;
                }
                catch
                {
                    return "UnknowBaseBoard";
                }
            }
        }

        private string UUID
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_ComputerSystemProduct");
                ManagementObjectCollection moc = mc.GetInstances();

                List<string> info = new List<string>();
                foreach (ManagementObject mo in moc)
                {
                    info.Add(mo["UUID"].ToString());
                }

                var obj = info.FirstOrDefault(p => !string.IsNullOrWhiteSpace(p));

                return string.IsNullOrWhiteSpace(obj) ? "HuanSi_UUID" : obj;
            }
        }

        /// <summary>
        /// BIOS SerialNumber
        /// </summary>
        /// <returns></returns>
        private string BiosSerialNumber
        {
            get
            {
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_BIOS");
                    ManagementObjectCollection moc = mc.GetInstances();
                    string strBiosID = string.Empty;
                    foreach (ManagementObject mo in moc)
                    {
                        strBiosID += mo["SerialNumber"].ToString().Trim();
                    }
                    if (string.IsNullOrEmpty(strBiosID)) throw new NullReferenceException("strBiosID");
                    return strBiosID;
                }
                catch
                {
                    return "UnknowBios";
                }
            }
        }

        #region IP地址
        /// <summary>
        /// 是否是IP4地址
        /// </summary>
        private bool IsIP4(string value)
        {
            const string pattern = @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))";
            return Regex.IsMatch(value, pattern);
        }

        public string IP4
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");

                ManagementObjectCollection moc = mc.GetInstances();

                string[] ips = null;
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString().Equals("True", StringComparison.CurrentCultureIgnoreCase))
                    {
                        ips = (string[])mo["IPAddress"];
                        foreach (var ip in ips)
                        {
                            if (IsIP4(ip))
                                return ip;
                        }
                    }
                }
                return string.Empty;
            }
        }

        public string IP6
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");

                ManagementObjectCollection moc = mc.GetInstances();

                string[] ips = null;
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString().Equals("True", StringComparison.CurrentCultureIgnoreCase))
                    {
                        ips = (string[])mo["IPAddress"];
                        foreach (var ip in ips)
                        {
                            if (!IsIP4(ip))
                                return ip;
                        }
                    }
                }

                return string.Empty;
            }
        }

        #endregion

    }
}