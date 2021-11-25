using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public event EventHandler<OnCloseChooseImageFormEvent> closeChooseImgForm;

        private ImageFileManager imageFileManager;
        private int imgIndexChoosen;


        public ChooseImageForm()
        {
            InitializeComponent();
        }

        private void ChooseImageForm_Load(object sender, EventArgs e)
        {
            imageFileManager = new ImageFileManager();
            ImageFileManager.CountImage = 0;
            ImageFileManager.IndexImage = 0;
            imageList.Images.Clear();
            imageLsview.Items.Clear();
            LoadImage();
        }

        private void LoadImage()
        {
            imageFileManager.GetListPathImageFromFolder();
            if (imageFileManager.ListPath.Count == 0) return;
            ImageFileManager.CountImage = imageFileManager.GetNumberImageCurrentFromFolder();
            
            foreach (var item in imageFileManager.ListPath.ToList())
            {
                imageFileManager.InitialImageList(imageLsview, imageList, item);
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
                MessageBox.Show("Có lỗi xảy ra khi đang xoá ảnh.\nVui lòng thử lại sau" +
                    " vài giây","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            imageLsview.Items.Clear();
            ImageFileManager.IndexImage = 0;
            StringCollection paths = imageList.Images.Keys;
            imageList.Images.Clear();
            foreach (var path in paths)
            {
                imageFileManager.InitialImageList(imageLsview, imageList, path);
            }
            
            delBtn.Enabled = false ;
            delBtn.Click -= DelBtn_Click;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                closeChooseImgForm?.Invoke(sender, new OnCloseChooseImageFormEvent
                    (imageList.Images.Keys[imgIndexChoosen]));
            }
            catch { };
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

    }
}
