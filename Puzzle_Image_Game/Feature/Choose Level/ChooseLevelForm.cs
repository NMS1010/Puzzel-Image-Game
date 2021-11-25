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
        public event EventHandler<OnCloseChooseLevelFormEvent> CloseLevelFormEvent;
        private LevelManager lvManager;

        public LevelManager LvManager { get => lvManager; set => lvManager = value; }

        public ChooseLevelForm()
        {
            InitializeComponent();
            LvManager = new LevelManager(pnlForm2, btnOKForm2);
        }
        public ChooseLevelForm(int levelChoosing)
        {
            InitializeComponent();
            LvManager = new LevelManager(pnlForm2, btnOKForm2);
            LvManager.LvChoosing = levelChoosing;
            LvManager.SetlevelChoosing();
        }

        private void btnOKForm2_Click(object sender, EventArgs e)
        {
            CloseLevelFormEvent?.Invoke(sender,
                new OnCloseChooseLevelFormEvent(LvManager.LevelChoosen()));
            Close();
        }
    }
}
