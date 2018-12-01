using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Network_Check
{
     class Call_Ping
    {
        public string CallPing(string host)
        {
            //------------使用ping类------
            string Address,Ttl,DontFragment,BufferSzie,RoundtripTime;
            //string host = "www.baidu.com";
            Ping p1 = new Ping();
            PingReply reply = p1.Send(host); //发送主机名或Ip地址
            StringBuilder sbuilder;
            if (reply.Status == IPStatus.Success)
            {
                sbuilder = new StringBuilder();

                /*
                sbuilder.AppendLine(string.Format("Address: {0} ", reply.Address.ToString()));               
                sbuilder.AppendLine(string.Format("Time to live: {0} ", reply.Options.Ttl));
                sbuilder.AppendLine(string.Format("Don't fragment: {0} ", reply.Options.DontFragment));
                sbuilder.AppendLine(string.Format("Buffer size: {0} ", reply.Buffer.Length));
                sbuilder.AppendLine(string.Format("RoundTrip time: {0} ", reply.RoundtripTime));
                Console.WriteLine(sbuilder.ToString());*/

                 Address = reply.Address.ToString();
                 Ttl = reply.Options.Ttl.ToString();
                 DontFragment = reply.Options.DontFragment.ToString();
                 BufferSzie = reply.Buffer.Length.ToString();
                 RoundtripTime = reply.RoundtripTime.ToString()+" ms";              
            }
            else if (reply.Status == IPStatus.TimedOut)
            {
                Console.WriteLine("超时");
                RoundtripTime = "超时";
            }
            else
            {
                Console.WriteLine("超时");
                RoundtripTime = "超时";
            }
            return RoundtripTime;
        }
    }
}
