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
        public override event EventHandler<FilledPictureBoxEventArgs> OnFilledPictureBox;

        private Panel panelBlank;

        public BlankBoard()
        {
            PanelBlank = new Panel();
        }
        public BlankBoard(int row, int col, int width, int height):base(row,col,width,height)
        {
            PanelBlank = new Panel();
            PanelBlank.Size = new Size(Width, Height);
        }

        public Panel PanelBlank { get => panelBlank; set => panelBlank = value; }


        public override void Reset()
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
        }
        public override void DrawBoard(List<Image> imgs, PuzzleGameForm fm)
        {
            Reset();
            int index = 0;

            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicBlank = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, i * imgs[index].Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicBlank = new PictureBox() { Size = new Size(imgs[index].Width, imgs[index].Height), Location = new Point(prevPicBlank.Location.X + prevPicBlank.Size.Width, prevPicBlank.Location.Y), BackColor = Color.LightGray };
                    currPicBlank.Paint += CurrPicBlank_Paint;
                    currPicBlank.MouseDown += CurrPicBlank_MouseDown;
                    this.AddImgToPanel(currPicBlank, PanelBlank, index, BorderStyle.FixedSingle);
                    prevPicBlank = currPicBlank;
                }
            }
            this.AddPanelToForm(fm, new Point(fm.Width / 12, fm.Height / 10), AnchorStyles.Left, PanelBlank);
        }

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

                OnFilledPictureBox?.Invoke(PanelBlank, new FilledPictureBoxEventArgs(PtrbList));
            }
        }
    }
}
