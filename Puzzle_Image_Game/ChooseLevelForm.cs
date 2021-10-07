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
    public partial class ChooseLevelForm : Form
    {
        private Level lv;

        public  Level Lv { get => lv; set => lv = value; }
        public event EventHandler<CloseChooseLevelFormEvent> CloseFormEvent;

        public ChooseLevelForm()
        {
            InitializeComponent();
            Lv = new Level(pnlForm2, btnOKForm2);
        }
        public ChooseLevelForm(int levelChoosing)
        {
            InitializeComponent();
            Lv = new Level(pnlForm2, btnOKForm2);
            Lv.LvChoosing = levelChoosing;
            Lv.SetlevelChoosing();
        }

        private void btnOKForm2_Click(object sender, EventArgs e)
        {
            CloseFormEvent?.Invoke(sender, new CloseChooseLevelFormEvent(Lv.LevelChoosen()));
            Close();
        }
    }
}
