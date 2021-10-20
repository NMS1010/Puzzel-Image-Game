
namespace Puzzle_Image_Game
{
    partial class ChooseImageForm
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
            this.components = new System.ComponentModel.Container();
            this.addImgFileBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.imageLsview = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // addImgFileBtn
            // 
            this.addImgFileBtn.Location = new System.Drawing.Point(671, 13);
            this.addImgFileBtn.Name = "addImgFileBtn";
            this.addImgFileBtn.Size = new System.Drawing.Size(194, 23);
            this.addImgFileBtn.TabIndex = 1;
            this.addImgFileBtn.Text = "Add Image From File";
            this.addImgFileBtn.UseVisualStyleBackColor = true;
            this.addImgFileBtn.Click += new System.EventHandler(this.addImgFileBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(671, 389);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(194, 23);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            this.openFileDlg.Filter = "File JPEG|*.jpg";
            // 
            // imageLsview
            // 
            this.imageLsview.AllowDrop = true;
            this.imageLsview.HideSelection = false;
            this.imageLsview.Location = new System.Drawing.Point(23, 13);
            this.imageLsview.Name = "imageLsview";
            this.imageLsview.Size = new System.Drawing.Size(619, 413);
            this.imageLsview.TabIndex = 0;
            this.imageLsview.UseCompatibleStateImageBehavior = false;
            this.imageLsview.SelectedIndexChanged += new System.EventHandler(this.imageLsview_SelectedIndexChanged);
            this.imageLsview.DragDrop += new System.Windows.Forms.DragEventHandler(this.imageLsview_DragDrop);
            this.imageLsview.DragEnter += new System.Windows.Forms.DragEventHandler(this.imageLsview_DragEnter);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChooseImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.addImgFileBtn);
            this.Controls.Add(this.imageLsview);
            this.MaximizeBox = false;
            this.Name = "ChooseImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Image Form";
            this.Load += new System.EventHandler(this.ChooseImageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addImgFileBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.ListView imageLsview;
        private System.Windows.Forms.ImageList imageList;
    }
}