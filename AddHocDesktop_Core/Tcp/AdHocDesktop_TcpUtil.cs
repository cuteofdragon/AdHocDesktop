using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace AdHocDesktop.Tcp
{
    public delegate void AdHocDesktop_TcpErrorEventHandler(object sender, string message);

    public class AdHocDesktop_TcpUtil
    {
        public static int DefaultServerPort = 168;
        public static IPAddress ResolveHostStringToIPAddress(string hostString)
        {
            //return IPAddress.Parse(hostString);
            
            IPHostEntry hostInfo = Dns.GetHostEntry(hostString);
            IPAddress[] addrs = hostInfo.AddressList;
            if (addrs.Length > 0)
            {
                return addrs[0];
            }
            else
            {
                throw new NullReferenceException("找不到可用的網路連線位址。");
            }             
        }
    }
}
