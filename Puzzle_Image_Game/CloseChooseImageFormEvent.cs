using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    public class CloseChooseImageFormEvent : EventArgs
    {
        private string imgPath;

        public CloseChooseImageFormEvent(string imgPath)
        {
            ImgPath = imgPath;
        }

        public string ImgPath { get => imgPath; set => imgPath = value; }
    }
}
