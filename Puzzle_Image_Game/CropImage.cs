using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    class CropImg
    {
        public Image ImgSource { get; set; }
        public string Src { get; set; }
        public int NumberOfColBoard { get; set; }
        public int NumberOfRowBoard { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public CropImg()
        {

        }
        public CropImg(int row, int col, Size sizeImg, string src)
        {
            Src = src;
            ImgSource = new Bitmap(Image.FromFile(Src), sizeImg);
            NumberOfColBoard = col;
            NumberOfRowBoard = row;
            Width = sizeImg.Width;
            Height = sizeImg.Height;
        }

        public List<Image> CropIntoListImgs()
        {
            List<Image> imgs = new List<Image>();
            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    var img = new Bitmap(Width / NumberOfRowBoard, Height / NumberOfColBoard);
                    using (var grp = Graphics.FromImage(img))
                    {
                        grp.DrawImage(ImgSource, new Rectangle(0, 0, Width / NumberOfRowBoard, Height / NumberOfColBoard), new Rectangle(j * Width / NumberOfRowBoard, i * Height / NumberOfColBoard, Width / NumberOfRowBoard, Height / NumberOfColBoard), GraphicsUnit.Pixel);
                    }
                    imgs.Add(img);
                }
            }
            return imgs;
        }
    }
}
