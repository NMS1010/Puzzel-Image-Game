using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public partial class SocketForm : Form
    {
        public SocketForm()
        {
            InitializeComponent();
            
        }


        private async void connectBtn_Click(object sender, EventArgs e)
        {
            SocketManager.tokenCancel.Cancel();
            await SocketManager.ConncetToServer(ipTxb.Text,int.Parse(portTxb.Text));
        }

        private async void SocketForm_Load(object sender, EventArgs e)
        {
            ipTxb.Text =  SocketManager.GetLocalIpv4Address();
            await SocketManager.WaitForClientConnect();
        }
    }
}
