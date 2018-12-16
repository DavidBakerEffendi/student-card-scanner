using StudentCardScanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCardScanner.Controller
{
    class NetworkController
    {
        private readonly DatabaseModel databaseModel;
        private readonly MainForm form;

        public NetworkController(MainForm form, DatabaseModel databaseModel)
        {
            this.form = form;
            this.databaseModel = databaseModel;

            ThreadStart checkNetwork = RunStatusCheck;
            new Thread(checkNetwork).Start();
        }

        private void RunStatusCheck()
        {
            while (!this.form.Created)
            {
                // Wait until form is created
                Thread.Sleep(100);
            }
            
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                this.form.SetNetworkConnectedStatus(true);
                this.form.SetNetworkLocalIP(GetLocalIPAddress());
            } else
            {
                this.form.SetNetworkConnectedStatus(false);
                this.form.SetNetworkLocalIP("n/a");
            }
            
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
