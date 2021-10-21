using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class Board
    {
        public virtual event EventHandler<OnFilledImageInBlankBoardEvemt> OnFilledPictureBox;

        protected static bool droppedImg = false;
        protected static Image holdImg = null;
        private List<PictureBox> ptrbList;
        private int numberOfColBoard;
        private int numberOfRowBoard;
        private int width;
        private int height;
        private Point position;

        public List<PictureBox> PtrbList { get => ptrbList; }
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

        protected void AddPanelToForm(PuzzleGameForm fm, Point pointPanel, AnchorStyles style, Panel panelAdded)
        {
            panelAdded.Location = pointPanel;
            panelAdded.Anchor = style;
            fm.Controls.Add(panelAdded);
        }
        protected void AddImgToPanel(PuzzleGameForm fm, PictureBox ptrb, Panel panel, int index, BorderStyle style)
        {
            ptrb.AllowDrop = true;
            ptrb.DragEnter += PtrbDropped_DragEnter;
            ptrb.DragDrop += PtrbDropped_DragDrop;

            ptrb.MouseEnter += Ptrb_MouseEnter;
            ptrb.MouseLeave += Ptrb_MouseLeave;
            
            ptrb.BorderStyle = style;
            ptrb.Tag = index;
            fm.Invoke((MethodInvoker)delegate
            {
                panel.Controls.Add(ptrb);
            });
            
        }

        private void Ptrb_MouseLeave(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint -= Ptrb_Paint;
            ptr.Refresh();
        }

        private void Ptrb_MouseEnter(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint += Ptrb_Paint;
            ptr.Refresh();
        }

        private void Ptrb_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private void PtrbDropped_DragDrop(object sender, DragEventArgs e)
        {
            var ptrb = sender as PictureBox;
            var img = e.Data.GetData(DataFormats.Bitmap) as Bitmap;
            if (ptrb.Image != img)
            {
                holdImg = ptrb.Image;
                ptrb.Image = img;
                droppedImg = true;
            }

        }
        private void PtrbDropped_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        public virtual void Reset()
        {
            holdImg = null;
            droppedImg = false;
            ptrbList = new List<PictureBox>();
        }
        protected void AddImageToPictureBox(List<Image> imgs, Panel panelImgList)
        {
            int index = 0;
            foreach(PictureBox item in panelImgList.Controls)
            {
                item.Image = imgs[index++];
            }
        }
        public virtual void DrawBoard(List<Image> imgs, PuzzleGameForm fm, Size sizeOfPtr)
        {
           
        }  

        protected void CurrPicBlank_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.White, ButtonBorderStyle.Solid);
        }
    }
}
