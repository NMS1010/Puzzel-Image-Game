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

        public event EventHandler<ClosePowerModifierFormEvent> HandleTimeWhenPressStart;
        public event EventHandler<ClosePowerModifierFormEvent> HandleTimeWhenPressCancel;
        public event EventHandler<ClosePowerModifierFormEvent> HandleTimeWhenClosing;

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
                FunctionInGame.modePowerChosen = chooseModeCbx.Text;
                FunctionInGame.isPowerStartClicked = true;
                FunctionInGame.timeSet = timeCbx;
                HandleTimeWhenPressStart?.Invoke(this, new ClosePowerModifierFormEvent(lbHour.Text, lbMinute.Text, lbSecond.Text, chooseModeCbx.Text));
            }
        }

        [Obsolete]
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            HandleTimeWhenPressCancel?.Invoke(this, new ClosePowerModifierFormEvent());
            FunctionInGame.StopThread();
            FunctionInGame.isPowerStartClicked = false;
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
            chooseModeCbx.Text = FunctionInGame.modePowerChosen;
            timePicker.Value = FunctionInGame.timeSet;
            lbHour.Text = FunctionInGame.timeList[0];
            lbMinute.Text = FunctionInGame.timeList[1];
            lbSecond.Text = FunctionInGame.timeList[2];
            if (FunctionInGame.isPowerStartClicked)
            {
                
                startBtn.Enabled = false;
                timePicker.Enabled = false;
                chooseModeCbx.Enabled = false;
                cancelBtn.Enabled = true;
                FunctionInGame.TimeCount(lbHour, lbMinute, lbSecond);
            }
            else
            {
                startBtn.Enabled = true;
                timePicker.Enabled = true;
                chooseModeCbx.Enabled = true;
            }
        }

        private void PowerModifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!FunctionInGame.isPowerStartClicked)
                HandleTimeWhenClosing?.Invoke(this, new ClosePowerModifierFormEvent());
        }
    }
}
