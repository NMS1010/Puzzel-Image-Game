
namespace Puzzle_Image_Game
{
    partial class PowerModifier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseModeCbx = new System.Windows.Forms.ComboBox();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(453, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xin mời bạn chọn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(475, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Điều chỉnh giờ:";
            // 
            // chooseModeCbx
            // 
            this.chooseModeCbx.FormattingEnabled = true;
            this.chooseModeCbx.Items.AddRange(new object[] {
            "Shut Down",
            "Restart"});
            this.chooseModeCbx.Location = new System.Drawing.Point(634, 17);
            this.chooseModeCbx.Name = "chooseModeCbx";
            this.chooseModeCbx.Size = new System.Drawing.Size(121, 21);
            this.chooseModeCbx.TabIndex = 1;
            this.chooseModeCbx.Text = "Shut Down";
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(634, 57);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(121, 20);
            this.timePicker.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(13, 104);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(775, 263);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(13, 404);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(75, 23);
            this.aboutBtn.TabIndex = 4;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = true;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(513, 404);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Location = new System.Drawing.Point(634, 404);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(404, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thời gian còn lại (giờ, phút, giây)";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.BackColor = System.Drawing.Color.White;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHour.ForeColor = System.Drawing.Color.Red;
            this.lbHour.Location = new System.Drawing.Point(287, 248);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(55, 37);
            this.lbHour.TabIndex = 6;
            this.lbHour.Text = "00";
            this.lbHour.TextChanged += new System.EventHandler(this.lbHour_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(348, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 37);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.BackColor = System.Drawing.Color.White;
            this.lbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinute.ForeColor = System.Drawing.Color.Red;
            this.lbMinute.Location = new System.Drawing.Point(381, 248);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(55, 37);
            this.lbMinute.TabIndex = 8;
            this.lbMinute.Text = "00";
            this.lbMinute.TextChanged += new System.EventHandler(this.lbHour_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(442, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 37);
            this.label7.TabIndex = 9;
            this.label7.Text = ":";
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.BackColor = System.Drawing.Color.White;
            this.lbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.Red;
            this.lbSecond.Location = new System.Drawing.Point(475, 248);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(55, 37);
            this.lbSecond.TabIndex = 10;
            this.lbSecond.Text = "00";
            this.lbSecond.TextChanged += new System.EventHandler(this.lbHour_TextChanged);
            // 
            // PowerModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbSecond);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbMinute);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.chooseModeCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "PowerModifier";
            this.Text = "BK AutoShutDown";
            this.Load += new System.EventHandler(this.PowerModifier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chooseModeCbx;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbSecond;
    }
}