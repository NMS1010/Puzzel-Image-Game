﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public class BlankBoard: Board
    {

        private Panel panelBlank;


        public BlankBoard()
        {
            PanelBlank = new Panel();
        }

        public BlankBoard(int row, int col, int width, int height, Point position)
            :base(row,col,width,height,position)
        {
            PanelBlank = new Panel
            {
                Size = new Size(Width, Height)
            };
        }

        public Panel PanelBlank { get => panelBlank; set => panelBlank = value; }

        public override void DrawBoard(Form fm, Size sizeOfPtr, BoardManager manager)
        {
            manager.Reset(PanelBlank);

            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicBlank = new PictureBox() { Size = new Size(0, 0),
                    Location = new Point(0, i * sizeOfPtr.Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicBlank = new PictureBox() { Size = new Size(sizeOfPtr.Width, sizeOfPtr.Height), 
                        Location = new Point(prevPicBlank.Location.X + prevPicBlank.Size.Width,
                        prevPicBlank.Location.Y), BackColor = Color.LightGray };
                    manager.AddPictureBoxToPanel(fm,currPicBlank, PanelBlank, indexPtrb++, BorderStyle.FixedSingle);
                    prevPicBlank = currPicBlank;
                }
            }
            manager.AddPanelToForm(fm, Position, AnchorStyles.Left, PanelBlank);
        }
    }
}
