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

        //lấy list path từ file
        public void GetListPathFromFile()
        {
            string path = "listPath.txt";

            using(var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamReader sr = new StreamReader(fs);
                
                while (!sr.EndOfStream)
                {
                    ListPath.Add(sr.ReadLine());
                }
            }
        }
        //Ghi list path ra file
        public void WriteListPathToFile()
        {
            string path = "listPath.txt";

            File.WriteAllText(path, String.Empty);
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fs) { AutoFlush = true};
                foreach (var item in ListPath)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public int GetNumberImageFromFolder()
        {
            string path = $@"..\..\Image\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var count = new List<string>(Directory.GetFiles(path));
            return count.Count;
        }
        public Bitmap GetImageFromFile(string path)
        {
            try
            {
                return new Bitmap(Image.FromFile(path), new Size(270, 270));
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn file ảnh", "Error", MessageBoxButtons.OK);
                return null;
            }
        }
        private string AddImageToFolderAndGetPath(string pth)
        {
            string dir = $@"..\..\Image\";
            string name = $"{CountImage}.jpg";
            Bitmap bmp = GetImageFromFile(pth);
            bmp.Save(dir + name, ImageFormat.Jpeg);
            CountImage++;
            return dir + name;
        }
        
        public void LoadImageBegin(ListView lsv, ImageList imgList, string path)
        {
            Image img = GetImageFromFile(path);
            if (img == null) return;
            imgList.ImageSize = new Size(100, 100);
            imgList.Images.Add(path, img);
            lsv.LargeImageList = imgList;
            lsv.Items.Add(String.Empty, IndexImage++);
        }
        public void AddImageToListView(ListView lsv, ImageList imgList, string path)
        {
            Image img = GetImageFromFile(path);
            if (img == null) return;
            string pth = AddImageToFolderAndGetPath(path);
            imgList.ImageSize = new Size(100, 100);
            imgList.Images.Add(pth,img);
            lsv.LargeImageList = imgList;
            lsv.Items.Add(String.Empty, IndexImage++);
        }
    }
}
