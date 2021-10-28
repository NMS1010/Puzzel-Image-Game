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
        private ImageFileManager imageFileManager;
        private int imgIndexChoosen;
        private string path;
        private List<string> pathImgRemoved;
        public event EventHandler<OnCloseChooseImageFormEvent> closeChooseImgForm;

        public ChooseImageForm()
        {
            InitializeComponent();
        }

        private void ChooseImageForm_Load(object sender, EventArgs e)
        {
            imageFileManager = new ImageFileManager();
            pathImgRemoved = new List<string>();
            ImageFileManager.CountImage = 0;
            ImageFileManager.IndexImage = 0;
            imageList.Images.Clear();
            imageLsview.Items.Clear();
            LoadImage();
        }

        private void LoadImage()
        {
            imageFileManager.GetListPathFromFile();
            if (imageFileManager.ListPath.Count == 0) return;
            ImageFileManager.CountImage = imageFileManager.GetNumberImageFromFolder();
            
            foreach (var item in imageFileManager.ListPath.ToList())
            {
                imageFileManager.LoadImageBegin(imageLsview, imageList, item);
            }
            
        }
        private void addImgFileBtn_Click(object sender, EventArgs e)
        {
            openFileDlg.Multiselect = false;
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                imageFileManager.AddImageToListView(imageLsview,imageList, openFileDlg.FileName);
            }
        }

        private void imageLsview_SelectedIndexChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = true;
            delBtn.Enabled = true;

            foreach(ListViewItem item in imageLsview.SelectedItems)
            {
                imgIndexChoosen = item.ImageIndex;
                
                if (imgIndexChoosen < 0 || imgIndexChoosen > imageList.Images.Count) break;
            }
            path = imageList.Images.Keys[imgIndexChoosen];
            okBtn.Click += OkBtn_Click;
            delBtn.Click += DelBtn_Click;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(imageList.Images.Keys[imgIndexChoosen]);
                imageList.Images.RemoveAt(imgIndexChoosen);
            }
            catch
            {
                return;
            }
            imageLsview.Items.Clear();
            ImageFileManager.IndexImage = 0;
            List<string> paths = new List<string>();
            foreach (var item in imageList.Images.Keys) {
                paths.Add(item);
            }
            imageList.Images.Clear();
            foreach (var item in paths)
            {
                imageFileManager.LoadImageBegin(imageLsview, imageList, item);
            }
            delBtn.Enabled = false ;
            delBtn.Click -= DelBtn_Click;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            closeChooseImgForm?.Invoke(sender, new OnCloseChooseImageFormEvent(path));

            Close();
        }

        private void imageLsview_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetData(DataFormats.FileDrop,true) is string[] filePaths)
            {
                foreach(var path in filePaths)
                {
                    imageFileManager.AddImageToListView(imageLsview, imageList, path);
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

        private void ChooseImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageFileManager.ListPath.Clear();
            foreach (var item in imageList.Images.Keys)
            {
                imageFileManager.ListPath.Add(item);
            }
            imageFileManager.WriteListPathToFile();
            imageList.Images.Clear();
            imageLsview.Items.Clear();

        }
    }
}
