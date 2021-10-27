using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    public class OnCloseChooseImageFormEvent : EventArgs
    {
        private Image img;

        public OnCloseChooseImageFormEvent(Image img)
        {
            Img = img;
        }

        public Image Img { get => img; set => img = value; }
    }
}
