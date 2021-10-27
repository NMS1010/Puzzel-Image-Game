using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class BlankBoard: Board
    {
        //public override event EventHandler<OnFilledImageInBlankBoardEvemt> OnFilledPictureBox;

        private Panel panelBlank;

        public BlankBoard()
        {
            PanelBlank = new Panel();
        }
        public BlankBoard(int row, int col, int width, int height, Point position) :base(row,col,width,height,position)
        {
            PanelBlank = new Panel();
            PanelBlank.Size = new Size(Width, Height);
        }

        public Panel PanelBlank { get => panelBlank; set => panelBlank = value; }


        /*public override void Reset()
        {
            PanelBlank.Controls.Clear();
            base.Reset();
        }
        public bool CheckFilledPanel()
        {
            foreach (PictureBox ptrb in PanelBlank.Controls)
            {
                if (ptrb.Image == null)
                {
                    return false;
                }
            }
            return true;
        }*/
        public override void DrawBoard(List<Image> imgs, PuzzleGameForm fm, Size sizeOfPtr)
        {
            BoardManager.Reset(PanelBlank);//
            int index = 0;

            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicBlank = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, i * sizeOfPtr.Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicBlank = new PictureBox() { Size = new Size(sizeOfPtr.Width, sizeOfPtr.Height), Location = new Point(prevPicBlank.Location.X + prevPicBlank.Size.Width, prevPicBlank.Location.Y), BackColor = Color.LightGray };
                    //currPicBlank.Paint += BoardManager.CurrPicBlank_Paint;
                    //currPicBlank.MouseDown += BoardManager.CurrPicBlank_MouseDown;
                    BoardManager.AddImgToPanel(fm,currPicBlank, PanelBlank, index++, BorderStyle.FixedSingle);//
                    prevPicBlank = currPicBlank;
                }
            }
            BoardManager.AddPanelToForm(fm, Position, AnchorStyles.Left, PanelBlank);//
        }
        /*
        private void CurrPicBlank_MouseDown(object sender, MouseEventArgs e)
        {
            var ptr = sender as PictureBox;
            if (ptr.Image == null) return;
            droppedImg = false;
            ptr.DoDragDrop(ptr.Image, DragDropEffects.Move);
            if (droppedImg)
                ptr.Image = holdImg;
            if (CheckFilledPanel())
            {
                PtrbList.AddRange(PanelBlank.Controls.OfType<PictureBox>());

                OnFilledPictureBox?.Invoke(PanelBlank, new OnFilledImageInBlankBoardEvemt(PtrbList));
            }
        }*/
    }
}
