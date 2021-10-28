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

        private Panel panelImgList;
        private List<Image> imgs;

        public ImageBoard()
        {
            PanelImgList = new Panel();
            Imgs = new List<Image>();
        }
        public ImageBoard(int row, int col, int width, int height, Point position, List<Image> imgs) : base(row, col, width, height, position)
        {
            PanelImgList = new Panel();
            PanelImgList.Size = new Size(Width, Height);
            Imgs = imgs;
        }

        public Panel PanelImgList { get => panelImgList; set => panelImgList = value; }
        public List<Image> Imgs { get => imgs; set => imgs = value; }

        public override void DrawBoard( PuzzleGameForm fm, Size sizeOfPtr)
        {
            BoardManager.Reset(PanelImgList);
            int index = 0;
            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                var prevPicImage = new PictureBox() { Size = new Size(0, 0), Location = new Point(0, i * sizeOfPtr.Height) };
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    PictureBox currPicImage = new PictureBox() { Size = new Size(sizeOfPtr.Width, sizeOfPtr.Height), Location = new Point(prevPicImage.Location.X + prevPicImage.Size.Width, prevPicImage.Location.Y) };
                    BoardManager.AddImgToPanel(fm,currPicImage, PanelImgList, index++, BorderStyle.FixedSingle);//
                    prevPicImage = currPicImage;
                }
            }
            BoardManager.AddImageToPictureBox(Imgs,PanelImgList);//
            BoardManager.AddPanelToForm(fm, Position, AnchorStyles.Right, PanelImgList);//
        }
       
    }
}
