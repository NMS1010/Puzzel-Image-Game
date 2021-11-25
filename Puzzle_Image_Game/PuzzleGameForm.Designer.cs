
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuzzleGameForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.musicplayerPnl = new System.Windows.Forms.Panel();
            this.repeatBtn = new System.Windows.Forms.PictureBox();
            this.pauseBtn = new System.Windows.Forms.PictureBox();
            this.songLbl = new System.Windows.Forms.Label();
            this.prevBtn = new System.Windows.Forms.PictureBox();
            this.nextBtn = new System.Windows.Forms.PictureBox();
            this.playBtn = new System.Windows.Forms.PictureBox();
            this.powerGrpBox = new System.Windows.Forms.GroupBox();
            this.lbS = new System.Windows.Forms.Label();
            this.lbM = new System.Windows.Forms.Label();
            this.lbNotation2 = new System.Windows.Forms.Label();
            this.lbNotation1 = new System.Windows.Forms.Label();
            this.lbH = new System.Windows.Forms.Label();
            this.lbTxt = new System.Windows.Forms.Label();
            this.OriginPtrb = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.levelCbx = new System.Windows.Forms.ComboBox();
            this.recordPanel = new System.Windows.Forms.Panel();
            this.recordLb1 = new System.Windows.Forms.Label();
            this.recordLb2 = new System.Windows.Forms.Label();
            this.recordLb3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mixToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.countDownPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timePlayNextSong = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.musicplayerPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBtn)).BeginInit();
            this.powerGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.recordPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.countDownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.musicplayerPnl);
            this.groupBox1.Controls.Add(this.powerGrpBox);
            this.groupBox1.Controls.Add(this.OriginPtrb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(0, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Image";
            // 
            // musicplayerPnl
            // 
            this.musicplayerPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.musicplayerPnl.Controls.Add(this.repeatBtn);
            this.musicplayerPnl.Controls.Add(this.pauseBtn);
            this.musicplayerPnl.Controls.Add(this.songLbl);
            this.musicplayerPnl.Controls.Add(this.prevBtn);
            this.musicplayerPnl.Controls.Add(this.nextBtn);
            this.musicplayerPnl.Controls.Add(this.playBtn);
            this.musicplayerPnl.Location = new System.Drawing.Point(361, 162);
            this.musicplayerPnl.Name = "musicplayerPnl";
            this.musicplayerPnl.Size = new System.Drawing.Size(377, 130);
            this.musicplayerPnl.TabIndex = 6;
            this.musicplayerPnl.Visible = false;
            // 
            // repeatBtn
            // 
            this.repeatBtn.Image = ((System.Drawing.Image)(resources.GetObject("repeatBtn.Image")));
            this.repeatBtn.Location = new System.Drawing.Point(205, 71);
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.Size = new System.Drawing.Size(50, 41);
            this.repeatBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.repeatBtn.TabIndex = 3;
            this.repeatBtn.TabStop = false;
            this.repeatBtn.Click += new System.EventHandler(this.repeatBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.Location = new System.Drawing.Point(124, 71);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(50, 41);
            this.pauseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.TabStop = false;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // songLbl
            // 
            this.songLbl.AutoSize = true;
            this.songLbl.Location = new System.Drawing.Point(28, 10);
            this.songLbl.MaximumSize = new System.Drawing.Size(250, 0);
            this.songLbl.Name = "songLbl";
            this.songLbl.Size = new System.Drawing.Size(0, 17);
            this.songLbl.TabIndex = 1;
            // 
            // prevBtn
            // 
            this.prevBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevBtn.Image")));
            this.prevBtn.Location = new System.Drawing.Point(31, 71);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(50, 41);
            this.prevBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.prevBtn.TabIndex = 0;
            this.prevBtn.TabStop = false;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextBtn.Image")));
            this.nextBtn.Location = new System.Drawing.Point(293, 71);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(50, 41);
            this.nextBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextBtn.TabIndex = 0;
            this.nextBtn.TabStop = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Image = ((System.Drawing.Image)(resources.GetObject("playBtn.Image")));
            this.playBtn.Location = new System.Drawing.Point(124, 71);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(50, 41);
            this.playBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playBtn.TabIndex = 0;
            this.playBtn.TabStop = false;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // powerGrpBox
            // 
            this.powerGrpBox.BackColor = System.Drawing.Color.White;
            this.powerGrpBox.Controls.Add(this.lbS);
            this.powerGrpBox.Controls.Add(this.lbM);
            this.powerGrpBox.Controls.Add(this.lbNotation2);
            this.powerGrpBox.Controls.Add(this.lbNotation1);
            this.powerGrpBox.Controls.Add(this.lbH);
            this.powerGrpBox.Controls.Add(this.lbTxt);
            this.powerGrpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerGrpBox.ForeColor = System.Drawing.Color.Red;
            this.powerGrpBox.Location = new System.Drawing.Point(923, 176);
            this.powerGrpBox.Name = "powerGrpBox";
            this.powerGrpBox.Size = new System.Drawing.Size(208, 137);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.levelCbx);
            this.groupBox2.Controls.Add(this.recordPanel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(503, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 181);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Record";
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
            // recordLb1
            // 
            this.recordLb1.AutoSize = true;
            this.recordLb1.Location = new System.Drawing.Point(18, 16);
            this.recordLb1.Name = "recordLb1";
            this.recordLb1.Size = new System.Drawing.Size(0, 13);
            this.recordLb1.TabIndex = 2;
            // 
            // recordLb2
            // 
            this.recordLb2.AutoSize = true;
            this.recordLb2.Location = new System.Drawing.Point(18, 54);
            this.recordLb2.Name = "recordLb2";
            this.recordLb2.Size = new System.Drawing.Size(0, 13);
            this.recordLb2.TabIndex = 1;
            // 
            // recordLb3
            // 
            this.recordLb3.AutoSize = true;
            this.recordLb3.Location = new System.Drawing.Point(18, 88);
            this.recordLb3.Name = "recordLb3";
            this.recordLb3.Size = new System.Drawing.Size(0, 13);
            this.recordLb3.TabIndex = 0;
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
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecond.ForeColor = System.Drawing.Color.Red;
            this.lbSecond.Location = new System.Drawing.Point(180, 95);
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
            this.lbMinute.Text = "03";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHour.ForeColor = System.Drawing.Color.Red;
            this.lbHour.Location = new System.Drawing.Point(60, 94);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(30, 24);
            this.lbHour.TabIndex = 1;
            this.lbHour.Text = "00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripOption
            // 
            this.menuStripOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mixToolStripMenuItem1,
            this.chooseImageToolStripMenuItem1,
            this.chooseLevelToolStripMenuItem,
            this.powerToolStripMenuItem,
            this.musicPlayerToolStripMenuItem});
            this.menuStripOption.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStripOption.ForeColor = System.Drawing.Color.Blue;
            this.menuStripOption.Name = "menuStripOption";
            this.menuStripOption.Size = new System.Drawing.Size(70, 25);
            this.menuStripOption.Text = "Option";
            // 
            // mixToolStripMenuItem1
            // 
            this.mixToolStripMenuItem1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.mixToolStripMenuItem1.Name = "mixToolStripMenuItem1";
            this.mixToolStripMenuItem1.ShortcutKeyDisplayString = "F1";
            this.mixToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mixToolStripMenuItem1.Size = new System.Drawing.Size(206, 26);
            this.mixToolStripMenuItem1.Text = "Mix";
            this.mixToolStripMenuItem1.Click += new System.EventHandler(this.mixToolStripMenuItem1_Click);
            // 
            // chooseImageToolStripMenuItem1
            // 
            this.chooseImageToolStripMenuItem1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.chooseImageToolStripMenuItem1.Name = "chooseImageToolStripMenuItem1";
            this.chooseImageToolStripMenuItem1.ShortcutKeyDisplayString = "F2";
            this.chooseImageToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.chooseImageToolStripMenuItem1.Size = new System.Drawing.Size(206, 26);
            this.chooseImageToolStripMenuItem1.Text = "Choose Image";
            this.chooseImageToolStripMenuItem1.Click += new System.EventHandler(this.chooseImageToolStripMenuItem1_Click);
            // 
            // chooseLevelToolStripMenuItem
            // 
            this.chooseLevelToolStripMenuItem.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.chooseLevelToolStripMenuItem.Name = "chooseLevelToolStripMenuItem";
            this.chooseLevelToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.chooseLevelToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.chooseLevelToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.chooseLevelToolStripMenuItem.Text = "Choose Level";
            this.chooseLevelToolStripMenuItem.Click += new System.EventHandler(this.chooseLevelToolStripMenuItem_Click);
            // 
            // powerToolStripMenuItem
            // 
            this.powerToolStripMenuItem.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.powerToolStripMenuItem.Name = "powerToolStripMenuItem";
            this.powerToolStripMenuItem.ShortcutKeyDisplayString = "F4";
            this.powerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.powerToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.powerToolStripMenuItem.Text = "Power";
            this.powerToolStripMenuItem.Click += new System.EventHandler(this.powerToolStripMenuItem_Click);
            // 
            // musicPlayerToolStripMenuItem
            // 
            this.musicPlayerToolStripMenuItem.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.musicPlayerToolStripMenuItem.Name = "musicPlayerToolStripMenuItem";
            this.musicPlayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.musicPlayerToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.musicPlayerToolStripMenuItem.Text = "Music Player";
            this.musicPlayerToolStripMenuItem.Click += new System.EventHandler(this.musicPlayerToolStripMenuItem_Click);
            // 
            // countDownPanel
            // 
            this.countDownPanel.Controls.Add(this.label7);
            this.countDownPanel.Controls.Add(this.label4);
            this.countDownPanel.Controls.Add(this.label3);
            this.countDownPanel.Controls.Add(this.label1);
            this.countDownPanel.Controls.Add(this.lbSecond);
            this.countDownPanel.Controls.Add(this.lbHour);
            this.countDownPanel.Controls.Add(this.lbMinute);
            this.countDownPanel.Location = new System.Drawing.Point(431, 44);
            this.countDownPanel.Name = "countDownPanel";
            this.countDownPanel.Size = new System.Drawing.Size(295, 148);
            this.countDownPanel.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Count Down Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(156, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(96, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = ":";
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
            this.label1.Text = "Trò chơi sẽ bắt đầu khi bạn click \r\n               vào 1 ô bất kì ";
            // 
            // timePlayNextSong
            // 
            this.timePlayNextSong.Tick += new System.EventHandler(this.timePlayNextSong_Tick);
            // 
            // PuzzleGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1156, 704);
            this.Controls.Add(this.countDownPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PuzzleGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PuzzleGameForm_FormClosed);
            this.Load += new System.EventHandler(this.PuzzleGameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.musicplayerPnl.ResumeLayout(false);
            this.musicplayerPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBtn)).EndInit();
            this.powerGrpBox.ResumeLayout(false);
            this.powerGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.recordPanel.ResumeLayout(false);
            this.recordPanel.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel musicplayerPnl;
        private System.Windows.Forms.Label songLbl;
        private System.Windows.Forms.PictureBox prevBtn;
        private System.Windows.Forms.PictureBox nextBtn;
        private System.Windows.Forms.PictureBox playBtn;
        private System.Windows.Forms.ToolStripMenuItem musicPlayerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pauseBtn;
        private System.Windows.Forms.PictureBox repeatBtn;
        private System.Windows.Forms.Timer timePlayNextSong;
    }
}

