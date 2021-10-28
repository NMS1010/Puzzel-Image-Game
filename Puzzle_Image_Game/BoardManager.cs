using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    class BoardManager
    {

        public static event EventHandler<OnFilledImageInBlankBoardEvent> OnFilledPictureBox;
        public static event EventHandler OnClickPictureBox;

        //Đánh dấu ảnh đã được thả sang ô khác hay chưa
        protected static bool droppedImg = false;
        //Giữ ảnh cần swap
        protected static Image holdImg = null;
        private static List<PictureBox> ptrbList;
        public static ImageBoard imgBoard;
        public static BlankBoard blankBoard;



        public BoardManager(int row, int col, int width, int height, Point blankBoardPos, Point imgBoardPos, List<Image> imgs)
        {
            imgBoard = new ImageBoard(row, col, width, height, imgBoardPos,imgs);
            blankBoard = new BlankBoard(row, col, width, height, blankBoardPos);
        }


        public void StartDraw(PuzzleGameForm fm, Size sizeOfPtr)
        {
            imgBoard.DrawBoard( fm, sizeOfPtr);
            blankBoard.DrawBoard(fm, sizeOfPtr);
        }

        public static void AddPanelToForm(PuzzleGameForm fm, Point pointPanel, AnchorStyles style, Panel panelAdded)
        {
            panelAdded.Location = pointPanel;
            panelAdded.Anchor = style;
            fm.Controls.Add(panelAdded);
        }
        public static void AddImgToPanel(PuzzleGameForm fm, PictureBox ptrb, Panel panel, int index, BorderStyle style)
        {
            ptrb.AllowDrop = true;
            ptrb.MouseDown += Ptrb_MouseDown;
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

        private static void Ptrb_MouseLeave(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint -= Ptrb_Paint;
            ptr.Refresh();
        }

        private static void Ptrb_MouseEnter(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint += Ptrb_Paint;
            ptr.Refresh();
        }

        private static void Ptrb_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

        private static void PtrbDropped_DragDrop(object sender, DragEventArgs e)
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
        private static void PtrbDropped_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        public static void Reset(Panel panel)
        {
            holdImg = null;
            droppedImg = false;
            ptrbList = new List<PictureBox>();
            panel.Controls.Clear();
        }
        public static void AddImageToPictureBox(List<Image> imgs, Panel panelImgList)
        {
            int index = 0;
            foreach (PictureBox item in panelImgList.Controls)
            {
                item.Image = imgs[index++];
            }
        }

        public static void CurrPicBlank_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        public static bool CheckFilledPanel()
        {
            foreach (PictureBox ptrb in blankBoard.PanelBlank.Controls)
            {
                if (ptrb.Image == null)
                {
                    return false;
                }
            }
            return true;
        }

        private static void Ptrb_MouseDown(object sender, MouseEventArgs e)
        {
            //Start count down time
            OnClickPictureBox?.Invoke(sender, e);


            var ptr = sender as PictureBox;
            if (ptr.Image == null) return;
            droppedImg = false;
            ptr.DoDragDrop(ptr.Image, DragDropEffects.Move);
            if (droppedImg)
                ptr.Image = holdImg;
            if (CheckFilledPanel())
            {
                ptrbList.AddRange(blankBoard.PanelBlank.Controls.OfType<PictureBox>());

                OnFilledPictureBox?.Invoke(blankBoard.PanelBlank, new OnFilledImageInBlankBoardEvent(ptrbList));
            }
        }
    }
}
