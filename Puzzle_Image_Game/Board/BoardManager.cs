using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public class BoardManager
    {

        public  event EventHandler<OnFilledImageInBlankBoardEvent> OnFilledPictureBox;
        public  event EventHandler OnClickPictureBox;

        //Đánh dấu ảnh đã được thả sang ô khác hay chưa
        protected  bool droppedImg = false;
        //Giữ ảnh cần swap
        private Image holdImg = null;
        private  List<PictureBox> ptrbList;

        public  ImageBoard imgBoard;
        public  BlankBoard blankBoard;

        public Image HoldImg { get => holdImg; set => holdImg = value; }

        public BoardManager(int row, int col, int width, int height,
            Point blankBoardPos, Point imgBoardPos, List<Image> imgs)
        {
            imgBoard = new ImageBoard(row, col, width, height, imgBoardPos,imgs);
            blankBoard = new BlankBoard(row, col, width, height, blankBoardPos);
        }


        public void StartDraw(Form fm, Size sizeOfPtr)
        {
            Board.indexPtrb = 0;
            imgBoard.DrawBoard( fm, sizeOfPtr,this);
            blankBoard.DrawBoard(fm, sizeOfPtr,this);
        }

        public  void AddPanelToForm(Form fm, Point pointPanel, 
            AnchorStyles style, Panel panelAdded)
        {
            panelAdded.Location = pointPanel;
            panelAdded.Anchor = style;
            fm.Controls.Add(panelAdded);
        }

        public  void AddPictureBoxToPanel(Form fm, PictureBox ptrb,
            Panel panel, int index, BorderStyle style)
        {
            ptrb.AllowDrop = true;
            ptrb.MouseDown -= Ptrb_MouseDown;
            ptrb.DragEnter -= PtrbDropped_DragEnter;
            ptrb.DragDrop -= PtrbDropped_DragDrop;

            ptrb.MouseEnter -= Ptrb_MouseEnter;
            ptrb.MouseLeave -= Ptrb_MouseLeave;

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

        private  void Ptrb_MouseLeave(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint -= Ptrb_Paint;
            ptr.Refresh();
        }

        private  void Ptrb_MouseEnter(object sender, EventArgs e)
        {
            var ptr = sender as PictureBox;
            ptr.Paint -= Ptrb_Paint;
            ptr.Paint += Ptrb_Paint;
            ptr.Refresh();
        }

        private  void Ptrb_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, 
                Color.Red, ButtonBorderStyle.Solid);
        }

        private  void PtrbDropped_DragDrop(object sender, DragEventArgs e)
        {
            var ptrb = sender as PictureBox;
            var img = e.Data.GetData(DataFormats.Bitmap) as Bitmap;
            if (ptrb.Image != img)
            {
                HoldImg = ptrb.Image;
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
        public void Reset(Panel panel)
        {
            HoldImg = null;
            droppedImg = false;
            ptrbList = new List<PictureBox>();
            panel.Controls.Clear();
        }
        public void AddImageToPictureBox(List<Image> imgs, Panel panelImgList)
        {
            int index = 0;
            foreach (PictureBox item in panelImgList.Controls)
            {
                item.Image = imgs[index++];
            }
        }

        public void CurrPicBlank_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                Color.White, ButtonBorderStyle.Solid);
        }

        public bool CheckFilledPanel()
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

        private  void Ptrb_MouseDown(object sender, MouseEventArgs e)
        {
            //Start count down time
            OnClickPictureBox?.Invoke(sender, e);
            var ptr = sender as PictureBox;
            if (ptr.Image == null) return;
            droppedImg = false;
            ptr.DoDragDrop(ptr.Image, DragDropEffects.Move);
            if (droppedImg)
                ptr.Image = HoldImg;
            if (CheckFilledPanel())
            {
                ptrbList = new List<PictureBox>();
                ptrbList.AddRange(blankBoard.PanelBlank.Controls.OfType<PictureBox>());

                OnFilledPictureBox?.Invoke(blankBoard.PanelBlank, new OnFilledImageInBlankBoardEvent(ptrbList));
            }

        }
    }
}
