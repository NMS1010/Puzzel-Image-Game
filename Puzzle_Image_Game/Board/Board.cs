using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public abstract class Board
    {
        private int numberOfColBoard;
        private int numberOfRowBoard;
        private int width;
        private int height;
        private Point position;
        public static int indexPtrb = 0;

        public int NumberOfColBoard { get => numberOfColBoard; set => numberOfColBoard = value; }
        public int NumberOfRowBoard { get => numberOfRowBoard; set => numberOfRowBoard = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Point Position { get => position; set => position = value; }

        public Board()
        {

        }

        public Board(int row, int col, int width, int height, Point position)
        {
            NumberOfColBoard = col;
            NumberOfRowBoard = row;
            Width = width;
            Height = height;
            Position = position;
        }

        public abstract void DrawBoard(Form fm, Size sizeOfPtr, BoardManager manager);
     
    }
}
