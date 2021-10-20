
namespace Puzzle_Image_Game
{
    partial class SocketForm
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
            this.ipTxb = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portTxb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ipTxb
            // 
            this.ipTxb.Location = new System.Drawing.Point(68, 50);
            this.ipTxb.Name = "ipTxb";
            this.ipTxb.Size = new System.Drawing.Size(206, 20);
            this.ipTxb.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(122, 135);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // portTxb
            // 
            this.portTxb.Location = new System.Drawing.Point(68, 90);
            this.portTxb.Name = "portTxb";
            this.portTxb.Size = new System.Drawing.Size(206, 20);
            this.portTxb.TabIndex = 2;
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 170);
            this.Controls.Add(this.portTxb);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.ipTxb);
            this.Name = "SocketForm";
            this.Text = "SocketForm";
            this.Load += new System.EventHandler(this.SocketForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTxb;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox portTxb;
    }
}