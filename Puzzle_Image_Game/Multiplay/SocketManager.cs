using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public class SocketManager
    {

        public event EventHandler<EventArgs> OnClientConnected;

        private static Random rd;
        public static int port;
        private bool isClient;
        private TcpClient client;
        private TcpListener listener;
        private NetworkStream netStream;
        private MultiplayForm fm;
        private SocketForm skForm;
        private string playerName;

        public bool IsClient { get => isClient; set => isClient = value; }
        public TcpClient Client { get => client; set => client = value; }
        public MultiplayForm Fm { get => fm; set => fm = value; }
        public SocketForm SkForm { get => skForm; set => skForm = value; }
        public string PlayerName { get => playerName; set => playerName = value; }
        public NetworkStream NetStream { get => netStream; set => netStream = value; }

        static SocketManager()
        {
            rd = new Random();
            port = rd.Next(6000, 7000);
        }

        public SocketManager(SocketForm skForm, string playerName)
        {
            Client = new TcpClient();
            listener = new TcpListener(IPAddress.Any,port);
            SkForm = skForm;
            PlayerName = playerName;
        }

        public void Send(object data)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(NetStream, data);
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        public object Receive()
        {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return binaryFormatter.Deserialize(NetStream);
        }

        [Obsolete]
        public void StartForm()
        { 

            try
            {
                fm = new MultiplayForm(this, isClient);

                fm.Show();
                
            }
            catch
            {
                return;
            }
        }

        [Obsolete]
        public async Task ConnectToServer(string ipServer, int port)
        {
            await Client.ConnectAsync(IPAddress.Parse(ipServer), port);

            if(Client.Connected)
            {
                NetStream = Client.GetStream();
                IsClient = true;
                StartForm();
            }
        }

        public async Task WaitForClientConnect()
        {
            port = rd.Next(6000, 7000);
            listener.Start();
            client = await listener.AcceptTcpClientAsync();
            NetStream = client.GetStream();
            OnClientConnected(this, new EventArgs());
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
            return ipV4[ipV4.Count - 1].ToString();
        }

    }
}
