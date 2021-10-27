using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class SocketManager
    {
        private static Random rd = new Random();
        //private static int port = rd.Next(6000, 7000); 
        private static int port = 6899;
        public static CancellationTokenSource tokenCancel = new CancellationTokenSource();
        public static async Task ConncetToServer(string ipServer, int port)
        {

            Action act = async () =>
            {
                //while (true)
                //{
                TcpClient client = new TcpClient();
                await client.ConnectAsync(IPAddress.Parse(ipServer), port);

                NetworkStream netStream = client.GetStream();

                StreamReader wr = new StreamReader(netStream);
                string text = wr.ReadLine();

                if (text == "Yes")
                {
                    MessageBox.Show("Success");
                }
                //}
            };

            Task t = new Task(act);
            t.Start();
            await t;
        }

        public static async Task WaitForClientConnect()
        {

            Action act = async () =>
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(GetLocalIpv4Address()),port);
                listener.Start();
                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();

                    NetworkStream netStream = client.GetStream();

                    StreamWriter sw = new StreamWriter(netStream);
                    sw.WriteLine("Yes");
                    if (tokenCancel.Token.IsCancellationRequested)
                    {
                        return;
                    }
                    if (MessageBox.Show("CÓ thiết bị kết nối tới", "Connecting", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        sw.Flush();
                    }

                }
            };

            Task t = new Task(act, tokenCancel.Token);
            t.Start();
            await t;
        }
        public static string GetLocalIpv4Address()
        {
            IPAddress[] ipList = Dns.GetHostAddresses(Dns.GetHostName());
            List<IPAddress> ipV4 = new List<IPAddress>();
            foreach(var ip in ipList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipV4.Add(ip);
                }
            }
            return ipV4[2].ToString();
        }
        public static string GetPublicIpv4Address()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }
    }
}
