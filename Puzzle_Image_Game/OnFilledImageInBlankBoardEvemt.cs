using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class OnFilledImageInBlankBoardEvemt: EventArgs
    {
        private List<PictureBox> ptrbList;
        
        public OnFilledImageInBlankBoardEvemt(List<PictureBox> ptrbs)
        {
            PtrbList = new List<PictureBox>();
            PtrbList = ptrbs;
            
        }

        public List<PictureBox> PtrbList { get => ptrbList; set => ptrbList = value; }
    }
}
