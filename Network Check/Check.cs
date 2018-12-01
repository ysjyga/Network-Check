using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Check
{
    class Check
    {
        public string run(string host,int prot)
        {
            Call_Ping cp = new Call_Ping();
            string RoundtripTime = cp.CallPing(host);

            Call_Telnet ct = new Call_Telnet();
            string r_tel = ct.CallTelnet(host, prot);
            return r_tel;


        }
}
}
