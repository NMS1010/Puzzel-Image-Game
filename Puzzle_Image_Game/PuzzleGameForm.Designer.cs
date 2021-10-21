
namespace Puzzle_Image_Game
{
    partial class PuzzleGameForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recordPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.powerGrpBox = new System.Windows.Forms.GroupBox();
            this.lbS = new System.Windows.Forms.Label();
            this.lbM = new System.Windows.Forms.Label();
            this.lbNotation2 = new System.Windows.Forms.Label();
            this.lbNotation1 = new System.Windows.Forms.Label();
            this.lbH = new System.Windows.Forms.Label();
            this.lbTxt = new System.Windows.Forms.Label();
            this.OriginPtrb = new System.Windows.Forms.PictureBox();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mixToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.countDownPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.recordLb3 = new System.Windows.Forms.Label();
            this.recordLb2 = new System.Windows.Forms.Label();
            this.recordLb1 = new System.Windows.Forms.Label();
            this.levelCbx = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.recordPanel.SuspendLayout();
            this.powerGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.countDownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.powerGrpBox);
            this.groupBox1.Controls.Add(this.OriginPtrb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Image";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.levelCbx);
            this.groupBox2.Controls.Add(this.recordPanel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(353, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 181);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Record";
            // 
            // recordPanel
            // 
            this.recordPanel.Controls.Add(this.recordLb1);
            this.recordPanel.Controls.Add(this.recordLb2);
            this.recordPanel.Controls.Add(this.recordLb3);
            this.recordPanel.Location = new System.Drawing.Point(6, 55);
            this.recordPanel.Name = "recordPanel";
            this.recordPanel.Size = new System.Drawing.Size(126, 120);
            this.recordPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Level";
            // 
            // powerGrpBox
            // 
            this.powerGrpBox.Controls.Add(this.lbS);
            this.powerGrpBox.Controls.Add(this.lbM);
            this.powerGrpBox.Controls.Add(this.lbNotation2);
            this.powerGrpBox.Controls.Add(this.lbNotation1);
            this.powerGrpBox.Controls.Add(this.lbH);
            this.powerGrpBox.Controls.Add(this.lbTxt);
            this.powerGrpBox.ForeColor = System.Drawing.Color.Red;
            this.powerGrpBox.Location = new System.Drawing.Point(929, 177);
            this.powerGrpBox.Name = "powerGrpBox";
            this.powerGrpBox.Size = new System.Drawing.Size(208, 136);
            this.powerGrpBox.TabIndex = 4;
            this.powerGrpBox.TabStop = false;
            this.powerGrpBox.Text = "Power";
            this.powerGrpBox.Visible = false;
            // 
            // lbS
            // 
            this.lbS.AutoSize = true;
            this.lbS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbS.Location = new System.Drawing.Point(170, 98);
            this.lbS.Name = "lbS";
            this.lbS.Size = new System.Drawing.Size(24, 18);
            this.lbS.TabIndex = 5;
            this.lbS.Text = "00";
            this.lbS.TextChanged += new System.EventHandler(this.Time_ChangeEvent);
            // 
            // lbM
            // 
            this.lbM.AutoSize = true;
            this.lbM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbM.Location = new System.Drawing.Point(88, 98);
            this.lbM.Name = "lbM";
            this.lbM.Size = new System.Drawing.Size(24, 18);
            this.lbM.TabIndex = 4;
            this.lbM.Text = "00";
            this.lbM.TextChanged += new System.EventHandler(this.Time_ChangeEvent);
            // 
            // lbNotation2
            // 
            this.lbNotation2.AutoSize = true;
            this.lbNotation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotation2.Location = new System.Drawing.Point(129, 98);
            this.lbNotation2.Name = "lbNotation2";
            this.lbNotation2.Size = new System.Drawing.Size(0, 18);
            this.lbNotation2.TabIndex = 3;
            // 
            // lbNotation1
            // 
            this.lbNotation1.AutoSize = true;
            this.lbNotation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotation1.Location = new System.Drawing.Point(47, 98);
            this.lbNotation1.Name = "lbNotation1";
            this.lbNotation1.Size = new System.Drawing.Size(0, 18);
            this.lbNotation1.TabIndex = 2;
            // 
            // lbH
            // 
            this.lbH.AutoSize = true;
            this.lbH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbH.Location = new System.Drawing.Point(6, 98);
            this.lbH.Name = "lbH";
            this.lbH.Size = new System.Drawing.Size(24, 18);
            this.lbH.TabIndex = 1;
            this.lbH.Text = "00";
            this.lbH.TextChanged += new System.EventHandler(this.Time_ChangeEvent);
            // 
            // lbTxt
            // 
            this.lbTxt.AutoSize = true;
            this.lbTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTxt.ForeColor = System.Drawing.Color.Red;
            this.lbTxt.Location = new System.Drawing.Point(23, 20);
            this.lbTxt.Name = "lbTxt";
            this.lbTxt.Size = new System.Drawing.Size(0, 24);
            this.lbTxt.TabIndex = 0;
            // 
            // OriginPtrb
            // 
            this.OriginPtrb.Location = new System.Drawing.Point(21, 43);
            this.OriginPtrb.Name = "OriginPtrb";
            this.OriginPtrb.Size = new System.Drawing.Size(270, 270);
            this.OriginPtrb.TabIndex = 0;
            this.OriginPtrb.TabStop = false;
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.Red;
            this.lbSecond.Location = new System.Drawing.Point(197, 94);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(30, 24);
            this.lbSecond.TabIndex = 3;
            this.lbSecond.Text = "00";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMinute.ForeColor = System.Drawing.Color.Red;
            this.lbMinute.Location = new System.Drawing.Point(120, 94);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(30, 24);
            this.lbMinute.TabIndex = 2;
            this.lbMinute.Text = "02";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHour.ForeColor = System.Drawing.Color.Red;
            this.lbHour.Location = new System.Drawing.Point(47, 94);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(30, 24);
            this.lbHour.TabIndex = 1;
            this.lbHour.Text = "00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripOption
            // 
            this.menuStripOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mixToolStripMenuItem1,
            this.chooseImageToolStripMenuItem1,
            this.chooseLevelToolStripMenuItem,
            this.powerToolStripMenuItem});
            this.menuStripOption.Name = "menuStripOption";
            this.menuStripOption.Size = new System.Drawing.Size(56, 20);
            this.menuStripOption.Text = "Option";
            // 
            // mixToolStripMenuItem1
            // 
            this.mixToolStripMenuItem1.Name = "mixToolStripMenuItem1";
            this.mixToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.mixToolStripMenuItem1.Text = "Mix";
            this.mixToolStripMenuItem1.Click += new System.EventHandler(this.mixToolStripMenuItem1_Click);
            // 
            // chooseImageToolStripMenuItem1
            // 
            this.chooseImageToolStripMenuItem1.Name = "chooseImageToolStripMenuItem1";
            this.chooseImageToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.chooseImageToolStripMenuItem1.Text = "Choose Image";
            this.chooseImageToolStripMenuItem1.Click += new System.EventHandler(this.chooseImageToolStripMenuItem1_Click);
            // 
            // chooseLevelToolStripMenuItem
            // 
            this.chooseLevelToolStripMenuItem.Name = "chooseLevelToolStripMenuItem";
            this.chooseLevelToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.chooseLevelToolStripMenuItem.Text = "Choose Level";
            this.chooseLevelToolStripMenuItem.Click += new System.EventHandler(this.chooseLevelToolStripMenuItem_Click);
            // 
            // powerToolStripMenuItem
            // 
            this.powerToolStripMenuItem.Name = "powerToolStripMenuItem";
            this.powerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.powerToolStripMenuItem.Text = "Power";
            this.powerToolStripMenuItem.Click += new System.EventHandler(this.powerToolStripMenuItem_Click);
            // 
            // countDownPanel
            // 
            this.countDownPanel.Controls.Add(this.label1);
            this.countDownPanel.Controls.Add(this.lbSecond);
            this.countDownPanel.Controls.Add(this.lbHour);
            this.countDownPanel.Controls.Add(this.lbMinute);
            this.countDownPanel.Location = new System.Drawing.Point(431, 44);
            this.countDownPanel.Name = "countDownPanel";
            this.countDownPanel.Size = new System.Drawing.Size(295, 148);
            this.countDownPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trò chơi sẽ bắt đầu khi bạn click \r\n    vào 1 ảnh bất kì ở bên phải";
            // 
            // recordLb3
            // 
            this.recordLb3.AutoSize = true;
            this.recordLb3.Location = new System.Drawing.Point(18, 88);
            this.recordLb3.Name = "recordLb3";
            this.recordLb3.Size = new System.Drawing.Size(0, 13);
            this.recordLb3.TabIndex = 0;
            // 
            // recordLb2
            // 
            this.recordLb2.AutoSize = true;
            this.recordLb2.Location = new System.Drawing.Point(18, 54);
            this.recordLb2.Name = "recordLb2";
            this.recordLb2.Size = new System.Drawing.Size(0, 13);
            this.recordLb2.TabIndex = 1;
            // 
            // recordLb1
            // 
            this.recordLb1.AutoSize = true;
            this.recordLb1.Location = new System.Drawing.Point(18, 16);
            this.recordLb1.Name = "recordLb1";
            this.recordLb1.Size = new System.Drawing.Size(0, 13);
            this.recordLb1.TabIndex = 2;
            // 
            // levelCbx
            // 
            this.levelCbx.FormattingEnabled = true;
            this.levelCbx.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.levelCbx.Location = new System.Drawing.Point(78, 24);
            this.levelCbx.Name = "levelCbx";
            this.levelCbx.Size = new System.Drawing.Size(43, 21);
            this.levelCbx.TabIndex = 3;
            this.levelCbx.Text = "3";
            this.levelCbx.SelectedIndexChanged += new System.EventHandler(this.levelCbx_SelectedIndexChanged);
            // 
            // PuzzleGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 704);
            this.Controls.Add(this.countDownPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PuzzleGameForm";
            this.Text = "Puzzle Image Game";
            this.Load += new System.EventHandler(this.PuzzleGameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.recordPanel.ResumeLayout(false);
            this.recordPanel.PerformLayout();
            this.powerGrpBox.ResumeLayout(false);
            this.powerGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.countDownPanel.ResumeLayout(false);
            this.countDownPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox OriginPtrb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem mixToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseLevelToolStripMenuItem;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.ToolStripMenuItem powerToolStripMenuItem;
        private System.Windows.Forms.GroupBox powerGrpBox;
        private System.Windows.Forms.Label lbS;
        private System.Windows.Forms.Label lbM;
        private System.Windows.Forms.Label lbNotation2;
        private System.Windows.Forms.Label lbNotation1;
        private System.Windows.Forms.Label lbH;
        private System.Windows.Forms.Label lbTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel countDownPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel recordPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label recordLb1;
        private System.Windows.Forms.Label recordLb2;
        private System.Windows.Forms.Label recordLb3;
        private System.Windows.Forms.ComboBox levelCbx;
    }
}

