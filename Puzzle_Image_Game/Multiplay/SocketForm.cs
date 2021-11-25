using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public partial class SocketForm : Form
    {
        SocketManager sk;
        private InitialGameForm startFm;

        [Obsolete]
        public SocketForm(InitialGameForm startFm)
        {
            InitializeComponent();
            this.startFm = startFm;
        }

        [Obsolete]
        private async void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await sk.ConnectToServer(ipTxb.Text, int.Parse(portTxb.Text));
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại, vui lòng kiểm tra địa chỉ IP và Port",
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void clientBtn_Click(object sender, EventArgs e)
        {
            serverBtn.Enabled = false;
            ipTxb.Enabled = portTxb.Enabled = connectBtn.Enabled = true;
            ipTxb.Text = SocketManager.GetLocalIpv4Address();
            portTxb.Text = SocketManager.port.ToString();
        }

        [Obsolete]
        private async void serverBtn_Click(object sender, EventArgs e)
        {
            clientBtn.Enabled = false;
            sk.IsClient = false;
            sk.StartForm();
            this.Hide();
            await sk.WaitForClientConnect();
        }

        private void nameTxb_TextChanged(object sender, EventArgs e)
        {
            if (nameTxb.Text == "")
            {
                infoLb.Text = "";
                return;
            }
            if(int.TryParse(nameTxb.Text[0].ToString(),out int res) || nameTxb.Text.Length>6)
            {
                infoLb.Visible = true;
                clientBtn.Enabled = serverBtn.Enabled = false;
                infoLb.Text = "Tên phải bắt đầu bằng chữ cái, độ dài không vượt quá 6";
                return;
            }
            infoLb.Text = "";
            clientBtn.Enabled = serverBtn.Enabled = true;
            sk = new SocketManager(this, nameTxb.Text);
        }

        private void SocketForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            startFm.Close();
        }
    }
}
