using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public class ImageFileManager
    {
        private static int countImage = 0;
        private static int indexImage = 0;
        private List<string> listPath;

        public ImageFileManager()
        {
            listPath = new List<string>();
        }

        public List<string> ListPath { get => listPath; set => listPath = value; }
        public static int CountImage { get => countImage; set => countImage = value; }
        public static int IndexImage { get => indexImage; set => indexImage = value; }

        public void GetListPathImageFromFolder()
        {
            string pathTemp = $@"..\..\Image\";
            if (!Directory.Exists(pathTemp)) Directory.CreateDirectory(pathTemp);
            listPath = new List<string>(Directory.GetFiles(pathTemp));
        }

        public int GetNumberImageCurrentFromFolder()
        {
            string path = $@"..\..\Image\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var count = new List<string>(Directory.GetFiles(path));
            int res = int.Parse(Path.GetFileNameWithoutExtension(count[count.Count - 1])) + 1;
            return res;
        }

        public Bitmap GetImageFromFile(string path)
        {
            try
            {
                using (var img = Image.FromFile(path))
                {
                    return new Bitmap(img, new Size(270, 270));
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn file ảnh hoặc kiểm tra lại đường dẫn", "Error", MessageBoxButtons.OK);
                return null;
            }
        }

        private string AddImageToFolderAndGetPath(string pth)
        {
            
            string dir = $@"..\..\Image\";
            string name = $"{CountImage}.jpg";
            using (Bitmap bmp = GetImageFromFile(pth))
            {
                bmp.Save(dir + name, ImageFormat.Jpeg);
            }
            CountImage++;
            
            return dir + name;
        }
        
        public void LoadImageBegin(ListView lsv, ImageList imgList, string path)
        {
            using (Image img = GetImageFromFile(path))
            {
                if (img == null) return;

                imgList.ImageSize = new Size(100, 100);
                imgList.Images.Add(path, img);
                lsv.LargeImageList = imgList;
                lsv.Items.Add(String.Empty, IndexImage++);
            }
        }
        public void AddImageToListView(ListView lsv, ImageList imgList, string path)
        {
            using (Image img = GetImageFromFile(path))
            {
                if (img == null) return;

                string pth = AddImageToFolderAndGetPath(path);
                imgList.ImageSize = new Size(100, 100);
                imgList.Images.Add(pth, img);
                lsv.LargeImageList = imgList;
                lsv.Items.Add(String.Empty, IndexImage++);
            }
        }
    }
}
