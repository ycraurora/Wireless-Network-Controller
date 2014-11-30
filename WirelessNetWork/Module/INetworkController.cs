using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace WirelessNetWork.Module
{
    public interface INetworkController
    {
        /// <summary>
        /// 获取所有网卡列表
        /// </summary>
        /// <returns>网卡名称列表</returns>
        List<string> GetNetworkList();
        /// <summary>
        /// 获取指定网卡
        /// </summary>
        /// <param name="NetworkName">网卡名称</param>
        /// <returns>网卡对象</returns>
        ManagementObject GetNetwork(string NetworkName);
        /// <summary>
        /// 获取指定网卡状态
        /// </summary>
        /// <param name="NetworkName">网卡名称</param>
        /// <returns>网卡状态</returns>
        bool GetNetworkState(string NetworkName);
        /// <summary>
        /// 启用指定网卡
        /// </summary>
        /// <param name="NetworkObject">网卡对象</param>
        /// <returns>执行状态</returns>
        bool EnableNetwork(ManagementObject NetworkObject);
        /// <summary>
        /// 禁用指定网卡
        /// </summary>
        /// <param name="NetworkObject">网卡对象</param>
        /// <returns>执行状态</returns>
        bool DisableNetwork(ManagementObject NetworkObject);
    }
}
