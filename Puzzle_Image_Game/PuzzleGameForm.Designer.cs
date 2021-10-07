
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
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbMinute = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.OriginPtrb = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSecond);
            this.groupBox1.Controls.Add(this.lbMinute);
            this.groupBox1.Controls.Add(this.lbHour);
            this.groupBox1.Controls.Add(this.OriginPtrb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1143, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Image";
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Location = new System.Drawing.Point(627, 54);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(19, 13);
            this.lbSecond.TabIndex = 3;
            this.lbSecond.Text = "01";
            // 
            // lbMinute
            // 
            this.lbMinute.AutoSize = true;
            this.lbMinute.Location = new System.Drawing.Point(561, 54);
            this.lbMinute.Name = "lbMinute";
            this.lbMinute.Size = new System.Drawing.Size(19, 13);
            this.lbMinute.TabIndex = 2;
            this.lbMinute.Text = "59";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Location = new System.Drawing.Point(496, 55);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(19, 13);
            this.lbHour.TabIndex = 1;
            this.lbHour.Text = "01";
            // 
            // OriginPtrb
            // 
            this.OriginPtrb.Location = new System.Drawing.Point(21, 43);
            this.OriginPtrb.Name = "OriginPtrb";
            this.OriginPtrb.Size = new System.Drawing.Size(270, 270);
            this.OriginPtrb.TabIndex = 0;
            this.OriginPtrb.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStripOption
            // 
            this.menuStripOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeToolStripMenuItem1,
            this.chooseImageToolStripMenuItem1,
            this.chooseLevelToolStripMenuItem,
            this.powerToolStripMenuItem});
            this.menuStripOption.Name = "menuStripOption";
            this.menuStripOption.Size = new System.Drawing.Size(56, 20);
            this.menuStripOption.Text = "Option";
            // 
            // mergeToolStripMenuItem1
            // 
            this.mergeToolStripMenuItem1.Name = "mergeToolStripMenuItem1";
            this.mergeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.mergeToolStripMenuItem1.Text = "Mix";
            this.mergeToolStripMenuItem1.Click += new System.EventHandler(this.mergeToolStripMenuItem1_Click);
            // 
            // chooseImageToolStripMenuItem1
            // 
            this.chooseImageToolStripMenuItem1.Name = "chooseImageToolStripMenuItem1";
            this.chooseImageToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.chooseImageToolStripMenuItem1.Text = "Choose Image";
            this.chooseImageToolStripMenuItem1.Click += new System.EventHandler(this.chooseImageToolStripMenuItem1_Click);
            // 
            // chooseLevelToolStripMenuItem
            // 
            this.chooseLevelToolStripMenuItem.Name = "chooseLevelToolStripMenuItem";
            this.chooseLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chooseLevelToolStripMenuItem.Text = "Choose Level";
            this.chooseLevelToolStripMenuItem.Click += new System.EventHandler(this.chooseLevelToolStripMenuItem_Click);
            // 
            // powerToolStripMenuItem
            // 
            this.powerToolStripMenuItem.Name = "powerToolStripMenuItem";
            this.powerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.powerToolStripMenuItem.Text = "Power";
            this.powerToolStripMenuItem.Click += new System.EventHandler(this.powerToolStripMenuItem_Click);
            // 
            // PuzzleGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 676);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PuzzleGameForm";
            this.Text = "Puzzle Image Game";
            this.Load += new System.EventHandler(this.PuzzleGameForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginPtrb)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox OriginPtrb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseLevelToolStripMenuItem;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.ToolStripMenuItem powerToolStripMenuItem;
    }
}

