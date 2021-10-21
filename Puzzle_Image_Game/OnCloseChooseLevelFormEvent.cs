using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    public class OnCloseChooseLevelFormEvent : EventArgs
    {
        private string level;
        public OnCloseChooseLevelFormEvent(string txt)
        {
            Level = txt;
        }

        public string Level { get => level; set => level = value; }
    }
}
