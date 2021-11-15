
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.ipTxb = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.portTxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clientBtn = new System.Windows.Forms.Button();
            this.serverBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTxb = new System.Windows.Forms.TextBox();
            this.infoLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipTxb
            // 
            this.ipTxb.Enabled = false;
            this.ipTxb.Location = new System.Drawing.Point(143, 121);
            this.ipTxb.Name = "ipTxb";
            this.ipTxb.Size = new System.Drawing.Size(206, 20);
            this.ipTxb.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.Enabled = false;
            this.connectBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(334, 236);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 27);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // portTxb
            // 
            this.portTxb.Enabled = false;
            this.portTxb.Location = new System.Drawing.Point(143, 164);
            this.portTxb.Name = "portTxb";
            this.portTxb.Size = new System.Drawing.Size(206, 20);
            this.portTxb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Your role";
            // 
            // clientBtn
            // 
            this.clientBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.clientBtn.Enabled = false;
            this.clientBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientBtn.Location = new System.Drawing.Point(143, 53);
            this.clientBtn.Name = "clientBtn";
            this.clientBtn.Size = new System.Drawing.Size(118, 44);
            this.clientBtn.TabIndex = 6;
            this.clientBtn.Text = "Client";
            this.clientBtn.UseVisualStyleBackColor = false;
            this.clientBtn.Click += new System.EventHandler(this.clientBtn_Click);
            // 
            // serverBtn
            // 
            this.serverBtn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.serverBtn.Enabled = false;
            this.serverBtn.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverBtn.Location = new System.Drawing.Point(292, 53);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(117, 44);
            this.serverBtn.TabIndex = 7;
            this.serverBtn.Text = "Server";
            this.serverBtn.UseVisualStyleBackColor = false;
            this.serverBtn.Click += new System.EventHandler(this.serverBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Enter your name";
            // 
            // nameTxb
            // 
            this.nameTxb.Location = new System.Drawing.Point(143, 10);
            this.nameTxb.Name = "nameTxb";
            this.nameTxb.Size = new System.Drawing.Size(266, 20);
            this.nameTxb.TabIndex = 9;
            this.nameTxb.TextChanged += new System.EventHandler(this.nameTxb_TextChanged);
            // 
            // infoLb
            // 
            this.infoLb.AutoSize = true;
            this.infoLb.ForeColor = System.Drawing.Color.Red;
            this.infoLb.Location = new System.Drawing.Point(140, 33);
            this.infoLb.Name = "infoLb";
            this.infoLb.Size = new System.Drawing.Size(0, 13);
            this.infoLb.TabIndex = 10;
            this.infoLb.Visible = false;
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(460, 275);
            this.Controls.Add(this.infoLb);
            this.Controls.Add(this.nameTxb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverBtn);
            this.Controls.Add(this.clientBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portTxb);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.ipTxb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SocketForm";
            this.Text = "SocketForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SocketForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTxb;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox portTxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox nameTxb;
        public System.Windows.Forms.Button clientBtn;
        public System.Windows.Forms.Button serverBtn;
        private System.Windows.Forms.Label infoLb;
    }
}