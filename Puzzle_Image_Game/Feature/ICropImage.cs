using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    interface ICropImage
    {
        List<Image> CropIntoListImgs(int NumberOfRowBoard, int NumberOfColBoard, Bitmap ImgSource, int Width, int Height);
    }
}
