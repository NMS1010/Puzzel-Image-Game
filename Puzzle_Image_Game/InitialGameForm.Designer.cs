
namespace Puzzle_Image_Game
{
    partial class InitialGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.singleplayBtn = new System.Windows.Forms.Button();
            this.multiplayBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Curlz MT", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(55, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "PUZZLE GAME";
            // 
            // singleplayBtn
            // 
            this.singleplayBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.singleplayBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.singleplayBtn.Font = new System.Drawing.Font("MingLiU-ExtB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleplayBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.singleplayBtn.Location = new System.Drawing.Point(114, 103);
            this.singleplayBtn.Name = "singleplayBtn";
            this.singleplayBtn.Size = new System.Drawing.Size(152, 35);
            this.singleplayBtn.TabIndex = 1;
            this.singleplayBtn.Text = "Single Play";
            this.singleplayBtn.UseVisualStyleBackColor = false;
            this.singleplayBtn.Click += new System.EventHandler(this.singleplayBtn_Click);
            // 
            // multiplayBtn
            // 
            this.multiplayBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.multiplayBtn.Font = new System.Drawing.Font("MingLiU-ExtB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplayBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.multiplayBtn.Location = new System.Drawing.Point(114, 144);
            this.multiplayBtn.Name = "multiplayBtn";
            this.multiplayBtn.Size = new System.Drawing.Size(152, 35);
            this.multiplayBtn.TabIndex = 2;
            this.multiplayBtn.Text = "Multi Play (LAN)";
            this.multiplayBtn.UseVisualStyleBackColor = false;
            this.multiplayBtn.Click += new System.EventHandler(this.multiplayBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.quitBtn.Font = new System.Drawing.Font("MingLiU-ExtB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.quitBtn.Location = new System.Drawing.Point(114, 226);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(152, 35);
            this.quitBtn.TabIndex = 4;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.aboutBtn.Font = new System.Drawing.Font("MingLiU-ExtB", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.aboutBtn.Location = new System.Drawing.Point(114, 185);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(152, 35);
            this.aboutBtn.TabIndex = 3;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // InitialGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(385, 273);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.multiplayBtn);
            this.Controls.Add(this.singleplayBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitialGameForm";
            this.Text = "Puzzle Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button singleplayBtn;
        private System.Windows.Forms.Button multiplayBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Button aboutBtn;
    }
}