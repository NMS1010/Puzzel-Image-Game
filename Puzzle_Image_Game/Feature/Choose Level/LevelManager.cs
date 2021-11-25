using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public class LevelManager
    {
        private string lvChoose;
        private int lvChoosing;
        private Panel pnlForm2;
        private Button btnOkForm2;

        public Panel PnlForm2 { get => pnlForm2; set => pnlForm2 = value; }
        public string LvChoose { get => lvChoose; set => lvChoose = value; }
        public Button BtnOkForm2 { get => btnOkForm2; set => btnOkForm2 = value; }
        public int LvChoosing { get => lvChoosing; set => lvChoosing = value; }

        public LevelManager(Panel pnlForm2, Button btnOkForm2)
        {
            PnlForm2 = pnlForm2;
            BtnOkForm2 = btnOkForm2;
        }
        public void SetlevelChoosing()
        {
            foreach (RadioButton item in PnlForm2.Controls)
            {
                if (item.Tag.ToString() == lvChoosing.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        public string LevelChoosen()
        {
            foreach(RadioButton item in PnlForm2.Controls)
            {
                item.CheckedChanged += Item_CheckedChanged;
                if (item.Checked)
                {
                    LvChoose = item.Tag.ToString();
                }
            }
            return LvChoose;
        }

        private void Item_CheckedChanged(object sender, EventArgs e)
        {
            BtnOkForm2.Enabled = true;
        }
    }
}
