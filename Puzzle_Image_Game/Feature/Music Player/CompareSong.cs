using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game.Feature.Music_Player
{
    public class CompareSong : IComparer<Song>
    {
        public int Compare(Song x, Song y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
