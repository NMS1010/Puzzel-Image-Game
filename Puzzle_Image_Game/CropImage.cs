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
        public static List<Image> CropIntoListImgs(int NumberOfRowBoard, int NumberOfColBoard, Bitmap ImgSource, int Width, int Height)
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
