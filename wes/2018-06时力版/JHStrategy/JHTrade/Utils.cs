using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JiaoHui.JHCore
{
    public class JHUtil
    {

        /// <summary>  
        /// 获取本机MAC地址  
        /// </summary>  
        /// <returns>本机MAC地址</returns>  
        public static string GetMacAddress()
        {
            try
            {
                string mac = "";
                ManagementClass mc;
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        mac = mo["MacAddress"].ToString();
                    }
                }
                return mac;
            }
            catch
            {
                JHLog.forTradeLog("获取本机MAC失败！");
                return "";
            }
        }

        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetNaviteIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
