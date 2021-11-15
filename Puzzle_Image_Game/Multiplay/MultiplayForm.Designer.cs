
namespace Puzzle_Image_Game
{
    partial class MultiplayForm
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OriginPtrb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mixBtn = new System.Windows.Forms.Button();
            this.chooseImgBtn = new System.Windows.Forms.Button();
            this.chooseLvBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.countDownPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.pnlScore = new System.Windows.Forms.Panel();
            this.lbServerPlayerScore = new System.Windows.Forms.Label();
            this.lbClientPlayerScore = new System.Windows.Forms.Label();
            this.lbServerPlayer = new System.Windows.Forms.Label();
            this.lbClientPlayer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.clientPlayerResultLb = new System.Windows.Forms.Label();
            this.serverPlayerResultLb = new System.Windows.Forms.Label();
            this.statusLb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).BeginInit();
            this.countDownPanel.SuspendLayout();
            this.pnlScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OriginPtrb);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(469, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Picture";
            // 
            // OriginPtrb
            // 
            this.OriginPtrb.Location = new System.Drawing.Point(6, 19);
            this.OriginPtrb.Name = "OriginPtrb";
            this.OriginPtrb.Size = new System.Drawing.Size(270, 270);
            this.OriginPtrb.TabIndex = 0;
            this.OriginPtrb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(528, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 1;
            // 
            // mixBtn
            // 
            this.mixBtn.BackColor = System.Drawing.Color.Beige;
            this.mixBtn.Enabled = false;
            this.mixBtn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mixBtn.Location = new System.Drawing.Point(475, 372);
            this.mixBtn.Name = "mixBtn";
            this.mixBtn.Size = new System.Drawing.Size(106, 23);
            this.mixBtn.TabIndex = 2;
            this.mixBtn.Text = "Mix";
            this.mixBtn.UseVisualStyleBackColor = false;
            this.mixBtn.Click += new System.EventHandler(this.mixBtn_Click);
            // 
            // chooseImgBtn
            // 
            this.chooseImgBtn.BackColor = System.Drawing.Color.Beige;
            this.chooseImgBtn.Enabled = false;
            this.chooseImgBtn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseImgBtn.Location = new System.Drawing.Point(643, 372);
            this.chooseImgBtn.Name = "chooseImgBtn";
            this.chooseImgBtn.Size = new System.Drawing.Size(106, 23);
            this.chooseImgBtn.TabIndex = 3;
            this.chooseImgBtn.Text = "Choose Image";
            this.chooseImgBtn.UseVisualStyleBackColor = false;
            this.chooseImgBtn.Click += new System.EventHandler(this.chooseImgBtn_Click);
            // 
            // chooseLvBtn
            // 
            this.chooseLvBtn.BackColor = System.Drawing.Color.Beige;
            this.chooseLvBtn.Enabled = false;
            this.chooseLvBtn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseLvBtn.Location = new System.Drawing.Point(547, 343);
            this.chooseLvBtn.Name = "chooseLvBtn";
            this.chooseLvBtn.Size = new System.Drawing.Size(130, 23);
            this.chooseLvBtn.TabIndex = 4;
            this.chooseLvBtn.Text = "Choose Level";
            this.chooseLvBtn.UseVisualStyleBackColor = false;
            this.chooseLvBtn.Visible = false;
            this.chooseLvBtn.Click += new System.EventHandler(this.chooseLvBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Beige;
            this.startBtn.Enabled = false;
            this.startBtn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(547, 401);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(130, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Visible = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // countDownPanel
            // 
            this.countDownPanel.Controls.Add(this.label4);
            this.countDownPanel.Controls.Add(this.label5);
            this.countDownPanel.Controls.Add(this.label2);
            this.countDownPanel.Controls.Add(this.lbSecond);
            this.countDownPanel.Controls.Add(this.lbHour);
            this.countDownPanel.Controls.Add(this.lbMinute);
            this.countDownPanel.Location = new System.Drawing.Point(475, 453);
            this.countDownPanel.Name = "countDownPanel";
            this.countDownPanel.Size = new System.Drawing.Size(274, 94);
            this.countDownPanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(163, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(96, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count Down Time";
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.Red;
            this.lbSecond.Location = new System.Drawing.Point(196, 46);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(30, 24);
            this.lbSecond.TabIndex = 3;
            this.lbSecond.Text = "00";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHour.ForeColor = System.Drawing.Color.Red;
            this.lbHour.Location = new System.Drawing.Point(53, 46);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(30, 24);
            this.lbHour.TabIndex = 1;
            this.lbHour.Text = "00";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinute.ForeColor = System.Drawing.Color.Red;
            this.lbMinute.Location = new System.Drawing.Point(122, 46);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(30, 24);
            this.lbMinute.TabIndex = 2;
            this.lbMinute.Text = "03";
            // 
            // pnlScore
            // 
            this.pnlScore.Controls.Add(this.lbServerPlayerScore);
            this.pnlScore.Controls.Add(this.lbClientPlayerScore);
            this.pnlScore.Controls.Add(this.lbServerPlayer);
            this.pnlScore.Controls.Add(this.lbClientPlayer);
            this.pnlScore.Controls.Add(this.label3);
            this.pnlScore.Location = new System.Drawing.Point(448, 553);
            this.pnlScore.Name = "pnlScore";
            this.pnlScore.Size = new System.Drawing.Size(332, 122);
            this.pnlScore.TabIndex = 7;
            // 
            // lbServerPlayerScore
            // 
            this.lbServerPlayerScore.AutoSize = true;
            this.lbServerPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerPlayerScore.ForeColor = System.Drawing.Color.Red;
            this.lbServerPlayerScore.Location = new System.Drawing.Point(235, 69);
            this.lbServerPlayerScore.Name = "lbServerPlayerScore";
            this.lbServerPlayerScore.Size = new System.Drawing.Size(18, 20);
            this.lbServerPlayerScore.TabIndex = 4;
            this.lbServerPlayerScore.Text = "0";
            // 
            // lbClientPlayerScore
            // 
            this.lbClientPlayerScore.AutoSize = true;
            this.lbClientPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientPlayerScore.ForeColor = System.Drawing.Color.Green;
            this.lbClientPlayerScore.Location = new System.Drawing.Point(72, 69);
            this.lbClientPlayerScore.Name = "lbClientPlayerScore";
            this.lbClientPlayerScore.Size = new System.Drawing.Size(18, 20);
            this.lbClientPlayerScore.TabIndex = 3;
            this.lbClientPlayerScore.Text = "0";
            // 
            // lbServerPlayer
            // 
            this.lbServerPlayer.AutoSize = true;
            this.lbServerPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lbServerPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerPlayer.ForeColor = System.Drawing.Color.Red;
            this.lbServerPlayer.Location = new System.Drawing.Point(234, 31);
            this.lbServerPlayer.Name = "lbServerPlayer";
            this.lbServerPlayer.Size = new System.Drawing.Size(67, 20);
            this.lbServerPlayer.TabIndex = 2;
            this.lbServerPlayer.Text = "Unknow";
            // 
            // lbClientPlayer
            // 
            this.lbClientPlayer.AutoSize = true;
            this.lbClientPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClientPlayer.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbClientPlayer.Location = new System.Drawing.Point(23, 31);
            this.lbClientPlayer.Name = "lbClientPlayer";
            this.lbClientPlayer.Size = new System.Drawing.Size(67, 20);
            this.lbClientPlayer.TabIndex = 1;
            this.lbClientPlayer.Text = "Unknow";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Score";
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.Beige;
            this.aboutBtn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBtn.Location = new System.Drawing.Point(587, 372);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 23);
            this.aboutBtn.TabIndex = 8;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // clientPlayerResultLb
            // 
            this.clientPlayerResultLb.AutoSize = true;
            this.clientPlayerResultLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientPlayerResultLb.Location = new System.Drawing.Point(76, 21);
            this.clientPlayerResultLb.Name = "clientPlayerResultLb";
            this.clientPlayerResultLb.Size = new System.Drawing.Size(0, 24);
            this.clientPlayerResultLb.TabIndex = 9;
            this.clientPlayerResultLb.TextChanged += new System.EventHandler(this.Label_TextChanged);
            // 
            // serverPlayerResultLb
            // 
            this.serverPlayerResultLb.AutoSize = true;
            this.serverPlayerResultLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPlayerResultLb.Location = new System.Drawing.Point(841, 21);
            this.serverPlayerResultLb.Name = "serverPlayerResultLb";
            this.serverPlayerResultLb.Size = new System.Drawing.Size(0, 24);
            this.serverPlayerResultLb.TabIndex = 10;
            this.serverPlayerResultLb.TextChanged += new System.EventHandler(this.Label_TextChanged);
            // 
            // statusLb
            // 
            this.statusLb.AutoSize = true;
            this.statusLb.Location = new System.Drawing.Point(547, 431);
            this.statusLb.Name = "statusLb";
            this.statusLb.Size = new System.Drawing.Size(0, 13);
            this.statusLb.TabIndex = 11;
            // 
            // MultiplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(1234, 687);
            this.Controls.Add(this.statusLb);
            this.Controls.Add(this.serverPlayerResultLb);
            this.Controls.Add(this.clientPlayerResultLb);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.pnlScore);
            this.Controls.Add(this.countDownPanel);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.chooseLvBtn);
            this.Controls.Add(this.chooseImgBtn);
            this.Controls.Add(this.mixBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MultiplayForm";
            this.Text = "MultiplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiplayForm_FormClosing);
            this.Load += new System.EventHandler(this.MultiplayForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).EndInit();
            this.countDownPanel.ResumeLayout(false);
            this.countDownPanel.PerformLayout();
            this.pnlScore.ResumeLayout(false);
            this.pnlScore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox OriginPtrb;
        private System.Windows.Forms.Panel countDownPanel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbSecond;
        public System.Windows.Forms.Label lbHour;
        public System.Windows.Forms.Label lbMinute;
        public System.Windows.Forms.Button mixBtn;
        public System.Windows.Forms.Button chooseImgBtn;
        private System.Windows.Forms.Panel pnlScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button aboutBtn;
        public System.Windows.Forms.Label lbServerPlayerScore;
        public System.Windows.Forms.Label lbClientPlayerScore;
        public System.Windows.Forms.Label lbServerPlayer;
        public System.Windows.Forms.Label lbClientPlayer;
        public System.Windows.Forms.Label clientPlayerResultLb;
        public System.Windows.Forms.Label serverPlayerResultLb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label statusLb;
        public System.Windows.Forms.Button chooseLvBtn;
        public System.Windows.Forms.Button startBtn;
    }
}