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
    public partial class InitialGameForm : Form
    {
        PuzzleGameForm GameFm;
        SocketForm socketForm;

        public InitialGameForm()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void singleplayBtn_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "PuzzleGameForm")
                {
                    frm.Dispose();
                }
            }
            GameFm = new PuzzleGameForm(this);
            GameFm.Show();
            Hide();
        }

        private void multiplayBtn_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "SocketForm")
                {
                    frm.Dispose();
                }
            }
            socketForm = new SocketForm(this);
            socketForm.Show();
            Hide();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string msg = "Puzzle Game là đồ án cuối kì môn OOP.\nThành viên đóng góp:\n 1.Nguyễn Minh Sơn\n 2.Nguyễn Đức Thành";
            MessageBox.Show(msg,"ABout",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
