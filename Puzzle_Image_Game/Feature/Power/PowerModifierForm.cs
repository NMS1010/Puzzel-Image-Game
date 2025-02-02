﻿using System;
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
    public partial class PowerModifierForm : Form
    {

        public event EventHandler<OnClosePowerModifierFormEvent> HandleTimeWhenPressStart;
        public event EventHandler<OnClosePowerModifierFormEvent> HandleTimeWhenPressCancel;
        public event EventHandler<OnClosePowerModifierFormEvent> HandleTimeWhenClosing;


        private GroupBox powerGrpBox;

        [Obsolete]
        public PowerModifierForm(GroupBox powerGrpBox)
        {
            this.powerGrpBox = powerGrpBox;
            InitializeComponent();
        }

        [Obsolete]
        public PowerModifierForm()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(timePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn thời gian sau thời gian hiện tại"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                startBtn.Enabled = false;
                timePicker.Enabled = false;
                chooseModeCbx.Enabled = false;
                cancelBtn.Enabled = true;

                TimeSpan countDownTime = timePicker.Value - DateTime.Now;

                lbHour.Text = GameFunction.HandleTime(countDownTime.Hours + countDownTime.Days * 24);
                lbMinute.Text = GameFunction.HandleTime(countDownTime.Minutes);
                lbSecond.Text = GameFunction.HandleTime(countDownTime.Seconds);
                GameFunction.TimeCount(lbHour, lbMinute, lbSecond, true);
                GameFunction.TimeEndEvent += GameFunction_TimeEndEvent;

                GameFunction.modePowerChosen = chooseModeCbx.Text;
                GameFunction.isPowerStartClicked = true;
                GameFunction.timeSet = timePicker.Value;

                HandleTimeWhenPressStart?.Invoke(this,
                    new OnClosePowerModifierFormEvent(lbHour.Text,
                    lbMinute.Text, lbSecond.Text, chooseModeCbx.Text));
            }
        }

        private void GameFunction_TimeEndEvent(object sender, EventArgs e)
        {
            if (lbHour.Text != "00" || lbMinute.Text != "00" || lbSecond.Text != "00") return;
            Power.PowerManager(chooseModeCbx.Text);
        }

        [Obsolete]
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            HandleTimeWhenPressCancel?.Invoke(this, new OnClosePowerModifierFormEvent());
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
            GameFunction.isPowerStartClicked = false;
            startBtn.Enabled = true;
            timePicker.Enabled = true;
            chooseModeCbx.Enabled = true;
        }


        [Obsolete]
        private void PowerModifier_Load(object sender, EventArgs e)
        {
            
            powerGrpBox.Visible = false;
            if (GameFunction.isPowerStartClicked)
            {
                chooseModeCbx.Text = GameFunction.modePowerChosen;
                timePicker.Value = GameFunction.timeSet;
                lbHour.Text = GameFunction.timeList[0];
                lbMinute.Text = GameFunction.timeList[1];
                lbSecond.Text = GameFunction.timeList[2];
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
                HandleTimeWhenClosing?.Invoke(this, new OnClosePowerModifierFormEvent(true));
            else
            {
                timePicker.Value = DateTime.Now;
                lbHour.Text = lbMinute.Text = lbSecond.Text = "00";
                HandleTimeWhenClosing?.Invoke(this, new OnClosePowerModifierFormEvent(false));
            }
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            if (timePicker.Value < DateTime.Now) {
                lbHour.Text = lbMinute.Text = lbSecond.Text = "00";
                return; 
            }

            TimeSpan countDownTime = timePicker.Value - DateTime.Now;

            lbHour.Text = GameFunction.HandleTime(countDownTime.Hours + countDownTime.Days * 24);
            lbMinute.Text = GameFunction.HandleTime(countDownTime.Minutes);
            lbSecond.Text = GameFunction.HandleTime(countDownTime.Seconds);
        }
    }
}
