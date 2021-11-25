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
        
        private string path;
       

        public OnCloseChooseImageFormEvent(string path)
        {
            Path = path;
        }
        
        public string Path { get => path; set => path = value; }
    }
}
