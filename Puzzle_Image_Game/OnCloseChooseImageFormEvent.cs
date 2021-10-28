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
        private string path;
        public OnCloseChooseImageFormEvent(Image img)
        {
            Img = img;
        }
        public OnCloseChooseImageFormEvent(string path)
        {
            Path = path;
        }
        public Image Img { get => img; set => img = value; }
        public string Path { get => path; set => path = value; }
    }
}
