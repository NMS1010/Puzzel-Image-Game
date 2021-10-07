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
    public partial class PowerModifier : Form
    {
        public PowerModifier()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            var timeCbx = timePicker.Value;
            if(timeCbx < DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn thời gian sau thời gian hiện tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                startBtn.Enabled = false;
                timePicker.Enabled = false;
                chooseModeCbx.Enabled = false;
                cancelBtn.Enabled = true;
                TimeSpan countDownTime = timeCbx - DateTime.Now;
                lbHour.Text =FunctionInGame.HandleTime(countDownTime.Hours + countDownTime.Days*24);
                lbMinute.Text = FunctionInGame.HandleTime(countDownTime.Minutes);
                lbSecond.Text = FunctionInGame.HandleTime(countDownTime.Seconds);
                FunctionInGame.TimeCount(lbHour, lbMinute, lbSecond);
                FunctionInGame.isPowerStartClicked = true;
                FunctionInGame.modePowerChosen = chooseModeCbx.Text;
            }
        }

        [Obsolete]
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if(FunctionInGame.Ts.IsAlive)
                FunctionInGame.Ts.Suspend();
            startBtn.Enabled = true;
            timePicker.Enabled = true;
            chooseModeCbx.Enabled = true;
        }

        private void lbHour_TextChanged(object sender, EventArgs e)
        {
            if (lbHour.Text != "00" || lbMinute.Text != "00" || lbSecond.Text != "00") return;
            Power.PowerManager(chooseModeCbx.Text);
        }

        [Obsolete]
        private void PowerModifier_Load(object sender, EventArgs e)
        {
           if (FunctionInGame.isPowerStartClicked)
            {
                startBtn.Enabled = false;
                timePicker.Enabled = false;
                chooseModeCbx.Text= FunctionInGame.modePowerChosen;
                chooseModeCbx.Enabled = false;
                cancelBtn.Enabled = true;
                lbHour.Text = FunctionInGame.timeList[0];
                lbMinute.Text = FunctionInGame.timeList[1];
                lbSecond.Text = FunctionInGame.timeList[2];
                if (FunctionInGame.Ts.IsAlive) 
                    FunctionInGame.Ts.Suspend();
                FunctionInGame.TimeCount(lbHour, lbMinute, lbSecond);
            }
        }
    }
}
