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
    public class ManageFileImage
    {
        private string fileName;
        private static int countImage = 0;
        private List<String> listPath;

        public ManageFileImage()
        {
            
        }

        public string FileName { get => fileName; set => fileName = value; }
        public List<String> ListPath { get => listPath; set => listPath = value; }
        public static int CountImage { get => countImage; set => countImage = value; }

        public void GetImageFromFolder()
        {
            string path = $@"..\..\Image\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            ListPath = new List<string>(Directory.GetFiles(path));
        }
        public Bitmap GetImageFromFile(string path)
        {
            try
            {
                if (String.IsNullOrEmpty(path))
                {
                    return new Bitmap(Image.FromFile(fileName), new Size(270, 270));
                }
                return new Bitmap(Image.FromFile(path), new Size(270, 270));
            }catch
            {
                MessageBox.Show("Vui lòng chọn file ảnh", "Error", MessageBoxButtons.OK);
                return null;
            }
        }
        private void AddImageToFolder()
        {
            if (String.IsNullOrEmpty(fileName)) return;
            string path = $@"..\..\Image\{CountImage+1}.jpg";
            Bitmap bmp = GetImageFromFile(fileName);
            bmp.Save(path, ImageFormat.Jpeg);
            ListPath.Add(path);
        }

        public void AddImageToListView(ListView lsv, ImageList imgList, string path)
        {
            Image img;
            if (String.IsNullOrEmpty(path))
            {
                img = GetImageFromFile(null);
            }
            else
            {
                img = GetImageFromFile(path);
            }
            if (img == null) return;
            imgList.ImageSize = new Size(100, 100);
            imgList.Images.Add(img);
            lsv.LargeImageList = imgList;
            lsv.Items.Add(CountImage.ToString(),CountImage);
            AddImageToFolder();
            CountImage++;
        }
    }
}
