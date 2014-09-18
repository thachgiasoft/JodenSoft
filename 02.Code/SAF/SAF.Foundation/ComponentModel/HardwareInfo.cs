using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Management;
using System.Security.Cryptography;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 硬件信息
    /// </summary>
    public static class HardwareInfo
    {
        public static string GetHardwareId()
        {
            return Encrypt(string.Format("{0}-{1}-{2}-{3}", GetCpuID(), GetBiosId(), GetBaseBoardID(), GetHardDiskID()));
        }
        /// <summary>
        /// 取CPU编号
        /// </summary>
        /// <returns></returns> 
        private static string GetCpuID()
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
        /// <summary>
        /// 取主板编号 
        /// </summary>
        /// <returns></returns>
        private static string GetBaseBoardID()
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
        /// <summary>
        /// 取第一块硬盘编号 
        /// </summary>
        /// <returns></returns>
        private static string GetHardDiskID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                string strHardDiskID = string.Empty;
                string strModel = string.Empty;
                foreach (ManagementObject mo in moc)
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    strModel = mo["Model"].ToString().Trim();
                    break;
                }
                if (string.IsNullOrEmpty(strHardDiskID) && string.IsNullOrEmpty(strModel)) throw new NullReferenceException("HardDiskID");
                return string.Format("{0}{1}", strHardDiskID, strModel);
            }
            catch
            {
                return "UnknowHardDisk";
            }
        }
        /// <summary>
        /// BIOS SerialNumber
        /// </summary>
        /// <returns></returns>
        private static string GetBiosId()
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

        /// <summary>
        /// Mac Address
        /// </summary>
        /// <returns></returns>
        private static string GetMacAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetWorkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                string strMac = string.Empty;
                foreach (ManagementObject mo in moc)
                {
                    if (mo["ServiceName"] != null && mo["MacAddress"] != null)
                    {
                        string mServiceName = mo["ServiceName"].ToString().ToLower();
                        if (mServiceName.Contains("vmnetadapter")
                            || mServiceName.Contains("ppoe")
                            || mServiceName.Contains("bthpan")
                            || mServiceName.Contains("tapvpn")
                            || mServiceName.Contains("ndisip")
                            || mServiceName.Contains("sinforvnic"))
                            continue;
                        strMac += mo["MacAddress"].ToString().Trim();
                    }
                }
                if (string.IsNullOrEmpty(strMac)) throw new NullReferenceException("strMac");
                return strMac.Replace(":", "");
            }
            catch
            {
                return "UnknowNetworkCard";
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string Encrypt(string value)
        {
            string retValue = string.Empty;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] retByte = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
                for (int i = 0; i < retByte.Length; i++)
                {
                    retValue += retByte[i].ToString("X").PadLeft(2, '0');
                }
                return new Guid(retValue).ToString("D").ToUpper();
            }
        }
    }
}