using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    [Serializable]
    public class PlayerInfo
    {
        private string name;
        private int score;
        private string elaspedTime;

        public PlayerInfo(string name, int score, string elaspedTime)
        {
            Name = name;
            Score = score;
            ElaspedTime = elaspedTime;
        }

        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
        public string ElaspedTime { get => elaspedTime; set => elaspedTime = value; }
    }
}
