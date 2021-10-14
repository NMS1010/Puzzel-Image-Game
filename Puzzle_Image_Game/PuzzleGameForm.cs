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
        private FunctionInGame fncGame;

        public PuzzleGameForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        [Obsolete]
        private void Start()
        {
            imgList = CropImg.CropIntoListImgs(numberOfRow, numberOfCol, new Bitmap(Image.FromFile(path),width,height),width,height);
            brdBlank.NumberOfColBoard = numberOfCol;
            brdBlank.NumberOfRowBoard = numberOfRow;

            brdImage.NumberOfColBoard = numberOfCol;
            brdImage.NumberOfRowBoard = numberOfRow;

            FunctionInGame.StopThreads(FunctionInGame.ThreadCountDown);
            lbMinute.Text = FunctionInGame.HandleTime(currentLevel);
            lbHour.Text = "00"; lbSecond.Text = "00";

            brdImage.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
            brdImage.OnClickPictureBox += BrdImage_OnClickPictureBox;
            brdBlank.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
        }

        private void BrdImage_OnClickPictureBox(object sender, EventArgs e)
        {
            FunctionInGame.TimeCount(lbHour, lbMinute, lbSecond,false);
            brdImage.OnClickPictureBox -= BrdImage_OnClickPictureBox;
        }

        [Obsolete]
        private void Brd_OnFilledPictureBox(object sender, FilledPictureBoxEventArgs e)
        {
            if (fncGame.IsWin(e.PtrbList, numberOfCol * numberOfRow, imgList))
            {
                FunctionInGame.StopThreads(FunctionInGame.ThreadCountDown);
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
            //brdBlank.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
            brdImage.DrawBoard(fncGame.Mix(GetListImageFromCurrentListPtrb(), numberOfCol * numberOfRow), this);
        }

        //private bool flagLevel = true;
        [Obsolete]
        private void chooseLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fncGame.ChooseLevel(numberOfCol);
            
            //if (flagLevel)
            //{
                fncGame.closeChooseLevelEvent += FncGame_closeChooseLevelEvent;
                //flagLevel = false;
            //}
        }

        [Obsolete]
        private void FncGame_closeChooseLevelEvent(object sender, CloseChooseLevelFormEvent e)
        {
            numberOfRow = numberOfCol = Convert.ToInt32(e.Level);
            currentLevel = int.Parse(e.Level);
            Start();
            /**/fncGame.closeChooseLevelEvent -= FncGame_closeChooseLevelEvent;
        }
        //private bool flagImg = true;
        private void chooseImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fncGame.ChooseImage();
            //if (flagImg)
            //{
                fncGame.closeChooseImageEvent += FncGame_closeChooseImageEvent;
                //flagImg = false;
            //}
        }

        [Obsolete]
        private void FncGame_closeChooseImageEvent(object sender, CloseChooseImageFormEvent e)
        {
            path = e.ImgPath;
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            Start();
            /**/fncGame.closeChooseImageEvent -= FncGame_closeChooseImageEvent;
        }

        [Obsolete]
        private void PuzzleGameForm_Load(object sender, EventArgs e)
        {
            path = @"1.jpg";
            List<Image> imgList = new List<Image>();
            fncGame = new FunctionInGame();
            resizedImg = new Size(width, height);
            brdBlank = new BlankBoard(numberOfRow, numberOfCol, width, height);
            brdImage = new ImageBoard(numberOfRow, numberOfCol, width, height, brdBlank);
            lbHour.Text = "00"; lbMinute.Text = "03"; lbSecond.Text = "00";
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            brdImage.OnFilledPictureBox += Brd_OnFilledPictureBox;
            brdBlank.OnFilledPictureBox += Brd_OnFilledPictureBox;
            Start();
        }
        //private bool flagPower = true;

        private void SetTimeForPowerForm()
        {
            FunctionInGame.timeList.Clear();
            FunctionInGame.timeList.Add(lbH.Text);
            FunctionInGame.timeList.Add(lbM.Text);
            FunctionInGame.timeList.Add(lbS.Text);
        }
        [Obsolete]
        private void powerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeForPowerForm();
            fncGame.PowerModify(powerGrpBox);
            //if (flagPower)
            //{
                fncGame.closePowerFormWhenPressCancelEvent += FncGame_closePowerFormWhenPressCancelEvent;
                fncGame.closePowerFormWhenPressStartEvent += FncGame_closePowerFormWhenPressStartEvent;
                fncGame.closePowerFormWhenClosingEvent += FncGame_closePowerFormWhenClosingEvent;
                //flagPower = false;
            //}

        }

        private void FncGame_closePowerFormWhenClosingEvent(object sender, ClosePowerModifierFormEvent e)
        {
            powerGrpBox.Visible = e.IsDisplay;
            //fncGame.closePowerFormWhenClosingEvent -= FncGame_closePowerFormWhenClosingEvent;
        }

        [Obsolete]
        private void FncGame_closePowerFormWhenPressCancelEvent(object sender, ClosePowerModifierFormEvent e)
        {
            FunctionInGame.StopThreads(FunctionInGame.ThreadsOfPowerForm);
            //fncGame.closePowerFormWhenPressCancelEvent -= FncGame_closePowerFormWhenPressCancelEvent;
        }

        private void FncGame_closePowerFormWhenPressStartEvent(object sender, ClosePowerModifierFormEvent e)
        {
            lbTxt.Text = $"    Your PC will\n {e.Mode} in about: ";
            lbH.Text = e.Hour;
            lbM.Text = e.Minute;
            lbS.Text = e.Second;
            lbNotation1.Text = ":";
            lbNotation2.Text = ":";
            FunctionInGame.TimeCount(lbH, lbM, lbS,true);
            //powerGrpBox.Visible = true;
            //fncGame.closePowerFormWhenPressStartEvent -= FncGame_closePowerFormWhenPressStartEvent;
        }

        private void Time_ChangeEvent(object sender, EventArgs e)
        {
            if (lbH.Text != "00" || lbM.Text != "00" || lbS.Text != "00") return;
            Power.PowerManager(FunctionInGame.modePowerChosen);
        }

        
    }
}
