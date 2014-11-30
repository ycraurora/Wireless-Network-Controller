using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WirelessNetWork.Module;
using System.Management;
using System.Threading;

namespace WirelessNetWork
{
    class Program
    {
        static void Main(string[] args)
        {
            INetworkController iNetworkController = ModuleFactory.GetNetworkController();
            //获取所有网卡名称列表
            //List<string> networkList = iNetworkController.GetNetworkList();
            //获取无线网卡
            ManagementObject wirelessNetwork = iNetworkController.GetNetwork("Realtek RTL8723AE Wireless LAN 802.11n PCI-E NIC");
            if (wirelessNetwork == null)
            {
                Console.WriteLine("获取无线网卡错误");
                Console.WriteLine("进程3秒后关闭");
                Thread.Sleep(3000);
                return;
            }
            else
            {
                Console.WriteLine("已获取无线网卡：" + "\n" + "Realtek RTL8723AE Wireless LAN 802.11n PCI-E NIC");
            }
            //获取无线网卡状态
            bool networkState = iNetworkController.GetNetworkState("Realtek RTL8723AE Wireless LAN 802.11n PCI-E NIC");
            if (networkState)
            {
                Console.WriteLine("");
                Console.WriteLine("无线网卡已开启");
                Console.WriteLine("正在禁用无线网卡...");
                Console.WriteLine("");
                if (iNetworkController.DisableNetwork(wirelessNetwork))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("无线网卡禁用成功");
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("无线网卡禁用失败");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("无线网卡已禁用");
                Console.WriteLine("正在开启无线网卡...");
                Console.WriteLine("");
                if (iNetworkController.EnableNetwork(wirelessNetwork))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("无线网卡开启成功");
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("无线网卡开启失败");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("进程3秒后关闭");
            Thread.Sleep(3000);
        }
    }
}
