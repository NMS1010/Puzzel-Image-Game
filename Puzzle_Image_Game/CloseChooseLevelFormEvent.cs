using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    public class CloseChooseLevelFormEvent : EventArgs
    {
        private string level;
        public CloseChooseLevelFormEvent(string txt)
        {
            Level = txt;
        }

        public string Level { get => level; set => level = value; }
    }
}
