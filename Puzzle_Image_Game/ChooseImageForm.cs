using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public partial class ChooseImageForm : Form
    {
        private ManageFileImage fileImage;
        private int imgIndexChoosen;
        public event EventHandler<OnCloseChooseImageFormEvent> closeChooseImgForm;

        public ChooseImageForm()
        {
            InitializeComponent();
        }

        private void LoadImageFromFolder()
        {
            fileImage.GetImageFromFolder();
            if (fileImage.ListPath.Count == 0 ) return;
            foreach(var item in fileImage.ListPath)
            {
                fileImage.AddImageToListView(imageLsview, imageList, item);
            }
        }
        private void addImgFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                fileImage.FileName = openFileDlg.FileName;
                fileImage.AddImageToListView(imageLsview,imageList,null);
            }
        }

        private void imageLsview_SelectedIndexChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = true;
            var lsvItem = sender as ListViewItem;
            foreach(ListViewItem item in imageLsview.SelectedItems)
            {
                imgIndexChoosen = item.ImageIndex;
                
                if (imgIndexChoosen < 0 || imgIndexChoosen > imageList.Images.Count) break;
            }
            okBtn.Click += OkBtn_Click;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            closeChooseImgForm?.Invoke(sender, new OnCloseChooseImageFormEvent(fileImage.ListPath[imgIndexChoosen]));
            Close();
        }

        private void imageLsview_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetData(DataFormats.FileDrop,true) is string[] filePaths)
            {
                foreach(var path in filePaths)
                {
                    fileImage.FileName = path;
                    fileImage.AddImageToListView(imageLsview, imageList, path);
                }
            }
        }

        private void imageLsview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ChooseImageForm_Load(object sender, EventArgs e)
        {
            fileImage = new ManageFileImage();
            ManageFileImage.CountImage = 0;
            LoadImageFromFolder();
        }
    }
}
