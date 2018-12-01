using System;
using System.IO;
using System.Net.Sockets;

namespace Network_Check
{
    class Call_Telnet
    {
         public string CallTelnet(string host,int port)
        {
            string ret;
            try
            {
                TcpClient tcpclient = new TcpClient();  // 连接服务器
                tcpclient.Connect(host, port);                
                Console.WriteLine(tcpclient.Connected);
                tcpclient.Close();
                ret = "通畅";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ret = "异常";
            }          
            return ret;
        }
    }
}
