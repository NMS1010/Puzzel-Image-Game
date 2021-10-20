using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Image_Game
{
    public partial class PuzzleGameForm : Form
    {
        private int width = 270;
        private int height = 270;
        private Size resizedImg;
        private string path;
        private static int currentLevel = 3;
        private int numberOfRow = currentLevel;
        private int numberOfCol = currentLevel;
        private List<Image> imgList;
        private BlankBoard brdBlank;
        private ImageBoard brdImage;
        private GameFunction fncGame;

        public PuzzleGameForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Start()
        {
            imgList = CropImg.CropIntoListImgs(numberOfRow, numberOfCol, new Bitmap(Image.FromFile(path),width,height),width,height);
            brdBlank.NumberOfColBoard = numberOfCol;
            brdBlank.NumberOfRowBoard = numberOfRow;

            brdImage.NumberOfColBoard = numberOfCol;
            brdImage.NumberOfRowBoard = numberOfRow;

            lbMinute.Text = GameFunction.HandleTime(currentLevel);
            lbSecond.Text = "00";
            lbHour.Text = "00";

            brdImage.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this, imgList[0].Size);
            brdImage.OnClickPictureBox += BrdImage_OnClickPictureBox;
            brdBlank.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this, imgList[0].Size);
            
        }

        private void BrdImage_OnClickPictureBox(object sender, EventArgs e)
        {
            GameFunction.TimeCount(lbHour, lbMinute, lbSecond,false);
            GameFunction.TimeEndEvent += CountDownTimeEvent;
            brdImage.OnClickPictureBox -= BrdImage_OnClickPictureBox;
        }

        [Obsolete]
        private void Brd_OnFilledPictureBox(object sender, FilledPictureBoxEventArgs e)
        {
            if (fncGame.IsWin(e.PtrbList, numberOfCol * numberOfRow, imgList))
            {
                GameFunction.StopThreads(GameFunction.ThreadCountDown);
                MessageBox.Show("Win");
            }
        }
        private List<Image> GetListImageFromCurrentListPtrb()
        {
            List<Image> res = new List<Image>();
            foreach(PictureBox ptrb in brdImage.PanelImgList.Controls)
            {
                res.Add(ptrb.Image);
            }
            return res;
        }
        private void mixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            brdImage.DrawBoard(fncGame.Mix(GetListImageFromCurrentListPtrb(), numberOfCol * numberOfRow), this, imgList[0].Size);
        }

        [Obsolete]
        private void chooseLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fncGame.ChooseLevel(numberOfCol);
            fncGame.closeChooseLevelEvent += FncGame_closeChooseLevelEvent;
        }

        [Obsolete]
        private void FncGame_closeChooseLevelEvent(object sender, CloseChooseLevelFormEvent e)
        {
            numberOfRow = numberOfCol = Convert.ToInt32(e.Level);
            currentLevel = int.Parse(e.Level);
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            Start();
            fncGame.closeChooseLevelEvent -= FncGame_closeChooseLevelEvent;
        }

        
        [Obsolete]
        private void chooseImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fncGame.ChooseImage();
            fncGame.closeChooseImageEvent += FncGame_closeChooseImageEvent;
        }

        [Obsolete]
        private void FncGame_closeChooseImageEvent(object sender, CloseChooseImageFormEvent e)
        {
            path = e.ImgPath;
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            Start();
            fncGame.closeChooseImageEvent -= FncGame_closeChooseImageEvent;
        }

        
        private void PuzzleGameForm_Load(object sender, EventArgs e)
        {
            path = @"1.jpg";
            List<Image> imgList = new List<Image>();
            fncGame = new GameFunction();
            resizedImg = new Size(width, height);
            brdBlank = new BlankBoard(numberOfRow, numberOfCol, width, height);
            brdImage = new ImageBoard(numberOfRow, numberOfCol, width, height, brdBlank);
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            brdImage.OnFilledPictureBox += Brd_OnFilledPictureBox;
            brdBlank.OnFilledPictureBox += Brd_OnFilledPictureBox;
            Start();
        }

        private void SetTimeForPowerForm()
        {
            GameFunction.timeList.Clear();
            GameFunction.timeList.Add(lbH.Text);
            GameFunction.timeList.Add(lbM.Text);
            GameFunction.timeList.Add(lbS.Text);
        }
        [Obsolete]
        private void powerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeForPowerForm();
            fncGame.PowerModify(powerGrpBox);
            fncGame.closePowerFormWhenPressCancelEvent += FncGame_closePowerFormWhenPressCancelEvent;
            fncGame.closePowerFormWhenPressStartEvent += FncGame_closePowerFormWhenPressStartEvent;
            fncGame.closePowerFormWhenClosingEvent += FncGame_closePowerFormWhenClosingEvent;

        }

        private void FncGame_closePowerFormWhenClosingEvent(object sender, ClosePowerModifierFormEvent e)
        {
            powerGrpBox.Visible = e.IsDisplay;
        }

        [Obsolete]
        private void FncGame_closePowerFormWhenPressCancelEvent(object sender, ClosePowerModifierFormEvent e)
        {
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
        }

        private void FncGame_closePowerFormWhenPressStartEvent(object sender, ClosePowerModifierFormEvent e)
        {
            lbTxt.Text = $"    Your PC will\n {e.Mode} in about: ";
            lbH.Text = e.Hour;
            lbM.Text = e.Minute;
            lbS.Text = e.Second;
            lbNotation1.Text = ":";
            lbNotation2.Text = ":";
            GameFunction.TimeCount(lbH, lbM, lbS,true);
        }

        private void Time_ChangeEvent(object sender, EventArgs e)
        {
            if (lbH.Text != "00" || lbM.Text != "00" || lbS.Text != "00") return;
            Power.PowerManager(GameFunction.modePowerChosen);
        }

        private void CountDownTimeEvent(object sender, EventArgs e)
        {
            if (lbHour.Text == "00" && lbMinute.Text == "00" && lbSecond.Text == "00")
            {
                if (MessageBox.Show("Bạn thua rồi\nBạn có muốn chơi lại?", "Result", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Start();
                }
            }
        }

    }
}
