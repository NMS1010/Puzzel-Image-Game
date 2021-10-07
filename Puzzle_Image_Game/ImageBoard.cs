using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class ImageBoard : Board
    {
        public override event EventHandler<FilledPictureBoxEventArgs> OnFilledPictureBox;
        private Panel panelImgList;
        private BlankBoard brdBlank;

        public ImageBoard()
        {
            PanelImgList = new Panel();
            brdBlank = new BlankBoard();
        }
        public ImageBoard(int row, int col, int width, int height, BlankBoard brdBlank) : base(row, col, width, height)
        {
            PanelImgList = new Panel();
            PanelImgList.Size = new Size(Width, Height);
            BrdBlank = brdBlank;
        }

        public Panel PanelImgList { get => panelImgList; set => panelImgList = value; }
        internal BlankBoard BrdBlank { get => brdBlank; set => brdBlank = value; }

        public override void Reset()
        {
            PanelImgList.Controls.Clear();
            base.Reset();
        }
        public override void DrawBoard(List<Image> imgs, PuzzleGameForm fm)
        {
            Reset();
            int index = 0;

            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicImage = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, i * imgs[index].Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicImage = new PictureBox() { Size = new Size(imgs[index].Width, imgs[index].Height), Location = new Point(prevPicImage.Location.X + prevPicImage.Size.Width, prevPicImage.Location.Y) };
                    currPicImage.MouseDown += CurrPicImage_MouseDown;
                    this.AddImgToPanel(currPicImage, PanelImgList, index, BorderStyle.FixedSingle);
                    prevPicImage = currPicImage;
                }
            }
            this.AddImageToPictureBox(imgs,PanelImgList);
            this.AddPanelToForm(fm, new Point(fm.Width - Width * 3 / 2, fm.Height / 10), AnchorStyles.Right, PanelImgList);
        }

        private void CurrPicImage_MouseDown(object sender, MouseEventArgs e)
        {
            var ptr = sender as PictureBox;
            if (ptr.Image == null) return;
            droppedImg = false;
            ptr.DoDragDrop(ptr.Image, DragDropEffects.Move);
            if (droppedImg)
                ptr.Image = holdImg;
            if (BrdBlank.CheckFilledPanel())
            {
                PtrbList.AddRange(BrdBlank.PanelBlank.Controls.OfType<PictureBox>());

                OnFilledPictureBox?.Invoke(BrdBlank.PanelBlank, new FilledPictureBoxEventArgs(PtrbList));
            }
        }
    }
}
