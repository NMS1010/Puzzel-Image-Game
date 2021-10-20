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


        private GroupBox powerGrpBox;
        public PowerModifier(GroupBox powerGrpBox)
        {
            this.powerGrpBox = powerGrpBox;
            InitializeComponent();
        }
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
                lbHour.Text =GameFunction.HandleTime(countDownTime.Hours + countDownTime.Days*24);
                lbMinute.Text = GameFunction.HandleTime(countDownTime.Minutes);
                lbSecond.Text = GameFunction.HandleTime(countDownTime.Seconds);
                GameFunction.TimeCount(lbHour, lbMinute, lbSecond,true);
                GameFunction.modePowerChosen = chooseModeCbx.Text;
                GameFunction.isPowerStartClicked = true;
                GameFunction.timeSet = timeCbx;
                HandleTimeWhenPressStart?.Invoke(this, new ClosePowerModifierFormEvent(lbHour.Text, lbMinute.Text, lbSecond.Text, chooseModeCbx.Text));
            }
        }

        [Obsolete]
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            HandleTimeWhenPressCancel?.Invoke(this, new ClosePowerModifierFormEvent());
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
            GameFunction.isPowerStartClicked = false;
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
            chooseModeCbx.Text = GameFunction.modePowerChosen;
            timePicker.Value = GameFunction.timeSet;
            lbHour.Text = GameFunction.timeList[0];
            lbMinute.Text = GameFunction.timeList[1];
            lbSecond.Text = GameFunction.timeList[2];
            powerGrpBox.Visible = false;
            if (GameFunction.isPowerStartClicked)
            {
                startBtn.Enabled = false;
                timePicker.Enabled = false;
                chooseModeCbx.Enabled = false;
                cancelBtn.Enabled = true;
                GameFunction.TimeCount(lbHour, lbMinute, lbSecond,true);
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
            if(GameFunction.isPowerStartClicked)
                HandleTimeWhenClosing?.Invoke(this, new ClosePowerModifierFormEvent(true));
            else
                HandleTimeWhenClosing?.Invoke(this, new ClosePowerModifierFormEvent(false));
        }
    }
}
