using StudentCardScanner.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace StudentCardScanner.Controller
{
    /// <summary>
    /// Controls network communications as the server for incoming clients and client data.
    /// </summary>
    /// <remarks>
    /// This class is to house the functionality of using mobile devices scanning cards, e.g smartphone NFC scanning apps.
    /// </remarks>
    class NetworkController
    {
        private readonly DatabaseModel databaseModel;
        private readonly MainForm form;

        /// <summary>
        /// The constructor 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="databaseModel"></param>
        public NetworkController(MainForm form, DatabaseModel databaseModel)
        {
            this.form = form;
            this.databaseModel = databaseModel;

            ThreadStart checkNetwork = RunStatusCheck;
            new Thread(checkNetwork).Start();
        }

        /// <summary>
        /// Checks the network status of the computer.
        /// </summary>
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

        /// <summary>
        /// Returns the IP address of this host on its local network.
        /// </summary>
        /// <returns>The local IPv4 address.</returns>
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
