using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game.Events
{
    public class OnPressPlayButtonMusicPlayer: EventArgs
    {
        private string name;
        public OnPressPlayButtonMusicPlayer(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
