using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace WirelessNetWork.Module.ModuleImpl
{
    public class NetworkController : INetworkController
    {
        private string netState = "SELECT * From Win32_NetworkAdapter";

        /// <summary>
        /// 获取所有网卡列表
        /// </summary>
        /// <returns>网卡对象列表</returns>
        public List<string> GetNetworkList()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            List<string> NetworkList = new List<string>();

            foreach (ManagementObject obj in collection)
            {
                NetworkList.Add(obj["Name"].ToString());

            }
            return NetworkList;
        }
        /// <summary>
        /// 获取指定网卡
        /// </summary>
        /// <param name="NetworkName">网卡名称</param>
        /// <returns>网卡对象</returns>
        public ManagementObject GetNetwork(string NetworkName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject obj in collection)
            {
                if (obj["Name"].ToString() == NetworkName)
                {
                    //返回指定名称的网卡
                    return obj;
                }
            }
            //若未查询到指定网卡则返回Null
            return null;
        }
        /// <summary>
        /// 获取指定网卡状态
        /// </summary>
        /// <param name="NetworkName">网卡名称</param>
        /// <returns>网卡状态</returns>
        public bool GetNetworkState(string NetworkName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject obj in collection)
            {
                if (obj["AdapterType"] != null)
                {
                    if (obj.Properties["AdapterType"].Value.ToString() == "Ethernet 802.3")
                    {
                        if (obj["Name"].ToString() == NetworkName)
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }
        /// <summary>
        /// 启用指定网卡
        /// </summary>
        /// <param name="NetworkObject">网卡对象</param>
        /// <returns>执行状态</returns>
        public bool EnableNetwork(ManagementObject NetworkObject)
        {
            try
            {
                NetworkObject.InvokeMethod("Enable", null);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 禁用指定网卡
        /// </summary>
        /// <param name="NetworkObject">网卡对象</param>
        /// <returns>执行状态</returns>
        public bool DisableNetwork(ManagementObject NetworkObject)
        {
            try
            {
                NetworkObject.InvokeMethod("Disable", null);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
