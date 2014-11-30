using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WirelessNetWork.Module.ModuleImpl;

namespace WirelessNetWork.Module
{
    public class ModuleFactory
    {
        /// <summary>
        /// 网卡控制功能接口实例化
        /// </summary>
        private static INetworkController iNetworkController = null;
        public static INetworkController GetNetworkController()
        {
            if (iNetworkController == null)
            {
                iNetworkController = new NetworkController();
            }
            return iNetworkController;
        }
    }
}
