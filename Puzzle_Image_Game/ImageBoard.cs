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
        public override event EventHandler<OnFilledImageInBlankBoardEvemt> OnFilledPictureBox;
        public event EventHandler OnClickPictureBox;
        private Panel panelImgList;
        private BlankBoard brdBlank;

        public ImageBoard()
        {
            PanelImgList = new Panel();
            brdBlank = new BlankBoard();
        }
        public ImageBoard(int row, int col, int width, int height, Point position, BlankBoard brdBlank) : base(row, col, width, height, position)
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
        public override void DrawBoard(List<Image> imgs, PuzzleGameForm fm, Size sizeOfPtr)
        {
            Reset();
            int index = 0;
            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicImage = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, i * sizeOfPtr.Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicImage = new PictureBox() { Size = new Size(sizeOfPtr.Width, sizeOfPtr.Height), Location = new Point(prevPicImage.Location.X + prevPicImage.Size.Width, prevPicImage.Location.Y) };
                    currPicImage.MouseDown += CurrPicImage_MouseDown;
                    this.AddImgToPanel(fm,currPicImage, PanelImgList, index++, BorderStyle.FixedSingle);
                    prevPicImage = currPicImage;
                }
            }
            this.AddImageToPictureBox(imgs,PanelImgList);
            this.AddPanelToForm(fm, Position, AnchorStyles.Right, PanelImgList);
        }

        private void CurrPicImage_MouseDown(object sender, MouseEventArgs e)
        {
            OnClickPictureBox?.Invoke(sender, e);
            var ptr = sender as PictureBox;
            if (ptr.Image == null) return;
            droppedImg = false;
            ptr.DoDragDrop(ptr.Image, DragDropEffects.Move);
            if (droppedImg)
                ptr.Image = holdImg;
            if (BrdBlank.CheckFilledPanel())
            {
                PtrbList.AddRange(BrdBlank.PanelBlank.Controls.OfType<PictureBox>());

                OnFilledPictureBox?.Invoke(BrdBlank.PanelBlank, new OnFilledImageInBlankBoardEvemt(PtrbList));
            }
        }
    }
}
