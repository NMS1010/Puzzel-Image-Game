
namespace Puzzle_Image_Game.Feature.Music_Player
{
    partial class MusicPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.topPnl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WMPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.songsLsbx = new System.Windows.Forms.ListBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.topPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // topPnl
            // 
            this.topPnl.BackColor = System.Drawing.Color.Lime;
            this.topPnl.Controls.Add(this.pictureBox1);
            this.topPnl.Controls.Add(this.label1);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 0);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(798, 42);
            this.topPnl.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(757, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Music Player";
            // 
            // WMPlayer
            // 
            this.WMPlayer.Enabled = true;
            this.WMPlayer.Location = new System.Drawing.Point(17, 266);
            this.WMPlayer.Name = "WMPlayer";
            this.WMPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMPlayer.OcxState")));
            this.WMPlayer.Size = new System.Drawing.Size(769, 155);
            this.WMPlayer.TabIndex = 1;
            this.WMPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WMPlayer_PlayStateChange);
            // 
            // songsLsbx
            // 
            this.songsLsbx.FormattingEnabled = true;
            this.songsLsbx.Location = new System.Drawing.Point(17, 67);
            this.songsLsbx.Name = "songsLsbx";
            this.songsLsbx.Size = new System.Drawing.Size(600, 173);
            this.songsLsbx.TabIndex = 2;
            this.songsLsbx.SelectedIndexChanged += new System.EventHandler(this.songsLsbx_SelectedIndexChanged);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(640, 67);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(146, 23);
            this.openBtn.TabIndex = 3;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Enabled = false;
            this.delBtn.Location = new System.Drawing.Point(640, 96);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(146, 23);
            this.delBtn.TabIndex = 3;
            this.delBtn.Text = "Delete";
            this.delBtn.UseVisualStyleBackColor = true;
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Location = new System.Drawing.Point(640, 125);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(146, 23);
            this.playBtn.TabIndex = 3;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 433);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.songsLsbx);
            this.Controls.Add(this.WMPlayer);
            this.Controls.Add(this.topPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MusicPlayerForm";
            this.Text = "MusicPlayerForm";
            this.Load += new System.EventHandler(this.MusicPlayerForm_Load);
            this.topPnl.ResumeLayout(false);
            this.topPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox songsLsbx;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button playBtn;
        public AxWMPLib.AxWindowsMediaPlayer WMPlayer;
    }
}