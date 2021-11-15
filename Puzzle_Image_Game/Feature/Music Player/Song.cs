using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game.Feature.Music_Player
{
    public class Song
    {
        private string path;
        private string name;

        public Song(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Path { get => path; set => path = value; }
        public string Name { get => name; set => name = value; }

    }
}
