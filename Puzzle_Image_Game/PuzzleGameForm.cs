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
    public partial class PuzzleGameForm : Form, ICropImage
    {
        private int width = 270;
        private int height = 270;
        private Size resizedImg;
        private string path;
        private static int currentLevel = 3;
        private int maxLevel = 10;
        private int numberOfRow = currentLevel;
        private int numberOfCol = currentLevel;
        private Image img;
        private List<Image> imgList;
        //private BlankBoard brdBlank;
        //private ImageBoard brdImage;
        private BoardManager boardManager;
        private List<List<int>> records;

        [Obsolete]
        public PuzzleGameForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        [Obsolete]
        private void PuzzleGameForm_Load(object sender, EventArgs e)
        {
            path = @"1.jpg";
            img = Image.FromFile(path);
            List<Image> imgList = new List<Image>();
            records = new List<List<int>>();
            for(int i = 0; i < maxLevel - 2; i++)
            {
                records.Add(new List<int>());
                records[i].Add(int.MaxValue);
                records[i].Add(int.MaxValue);
                records[i].Add(int.MaxValue);
            }
            resizedImg = new Size(width, height);
            //brdBlank = new BlankBoard(numberOfRow, numberOfCol, width, height, new Point(this.Width / 12, this.Height / 10));
            //brdImage = new ImageBoard(numberOfRow, numberOfCol, width, height, new Point(this.Width - width * 3 / 2, this.Height / 10), brdBlank);
            boardManager = new BoardManager(numberOfRow, numberOfCol, width, height, new Point(this.Width / 12, this.Height / 10), new Point(this.Width - width * 3 / 2, this.Height / 10));
            OriginPtrb.Image = new Bitmap(img, resizedImg);
            BoardManager.OnFilledPictureBox += Brd_OnFilledImageInBlankBoardEvemt;
            //brdImage.OnFilledPictureBox += Brd_OnFilledImageInBlankBoardEvemt;
            //brdBlank.OnFilledPictureBox += Brd_OnFilledImageInBlankBoardEvemt;
            Start();
        }

        private int ConvertTimeToSecond(string time)
        {
            string[] temp = time.Split(':');
            int result = int.Parse(temp[0]) * 3600 + int.Parse(temp[1]) * 60 + int.Parse(temp[2]);
            return result;
        }
        private string ConvertSecondToTime(int second)
        {
            int h, m, s;
            h = (int)Math.Floor(second / (Double)3600);
            m = (int)Math.Floor((second % 3600) / (Double)60);
            s = second % 3600 % 60;
            return $"{GameFunction.HandleTime(h)}:{GameFunction.HandleTime(m)}:{GameFunction.HandleTime(s)}";
        }
        private void UpdateRecordTable(int level)
        {
            int i = 0;
            int number = 1;
            foreach(Label item in recordPanel.Controls)
            {
                if(records[level - 3][i] != int.MaxValue)
                {
                    item.Text = $"{number}. " + ConvertSecondToTime(records[level - 3][i]);
                    number++;
                }
                else
                {
                    item.Text = "";
                }
                i++;
            }

        }
        private void Start()
        {
            numberOfRow = numberOfCol = currentLevel;
            imgList = CropIntoListImgs(numberOfRow, numberOfCol, new Bitmap(img,width,height),width,height);
            BoardManager.blankBoard.NumberOfRowBoard = numberOfRow;
            BoardManager.blankBoard.NumberOfColBoard = numberOfCol;
            //brdBlank.NumberOfColBoard = numberOfCol;
            //brdBlank.NumberOfRowBoard = numberOfRow;
            BoardManager.imgBoard.NumberOfRowBoard = numberOfRow;
            BoardManager.imgBoard.NumberOfColBoard = numberOfCol;
            //brdImage.NumberOfColBoard = numberOfCol;
            //brdImage.NumberOfRowBoard = numberOfRow;


            lbMinute.Text = GameFunction.HandleTime(currentLevel);
            lbSecond.Text = "00";
            lbHour.Text = "00";

            //brdImage.DrawBoard(GameFunction.Mix(imgList, numberOfCol * numberOfRow), this, imgList[0].Size);
            //brdImage.OnClickPictureBox += BrdImage_OnClickPictureBox;
            //brdBlank.DrawBoard(GameFunction.Mix(imgList, numberOfCol * numberOfRow), this, imgList[0].Size);
            boardManager.StartDraw(GameFunction.Mix(imgList, numberOfCol * numberOfRow), this, imgList[0].Size);
            BoardManager.OnClickPictureBox += BrdImage_OnClickPictureBox;
        }

        private void BrdImage_OnClickPictureBox(object sender, EventArgs e)
        {
            GameFunction.TimeCount(lbHour, lbMinute, lbSecond,false);
            GameFunction.TimeEndEvent += CountDownTimeEvent;
            //brdImage.OnClickPictureBox -= BrdImage_OnClickPictureBox;
            BoardManager.OnClickPictureBox -= BrdImage_OnClickPictureBox;
        }

        private string TimeElapse(string hour, string minute, string second)
        {
            int totalSecondRemain = ConvertTimeToSecond($"{hour}:{minute}:{second}");

            int timeElapse = currentLevel * 60 - totalSecondRemain;

            return ConvertSecondToTime(timeElapse);
        }

        [Obsolete]
        private void Brd_OnFilledImageInBlankBoardEvemt(object sender, OnFilledImageInBlankBoardEvemt e)
        {
            if (GameFunction.IsWin(e.PtrbList, numberOfCol * numberOfRow, imgList))
            {
                GameFunction.StopThreads(GameFunction.ThreadCountDown);
                string time = TimeElapse(lbHour.Text, lbMinute.Text, lbSecond.Text);
                records[currentLevel-3].Add(ConvertTimeToSecond(time));
                records[currentLevel-3].Sort();
                records[currentLevel].RemoveRange(3, records[currentLevel].Count - 3);
                UpdateRecordTable(currentLevel);
                if (MessageBox.Show($"Great! You won\nTime elapse: {time}\nClick OK to go to next challenge\nClick Cancel to play again","Result",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    currentLevel += 1;
                }
                levelCbx.Text = currentLevel.ToString();
                if (currentLevel > 10)
                {
                    MessageBox.Show("There is no challenge for you! Congratulation!");
                    currentLevel = 10;
                }
                Start();
            }
        }

        private List<Image> GetListImageFromCurrentListPtrb()
        {
            List<Image> res = new List<Image>();
            foreach(PictureBox ptrb in BoardManager.imgBoard.PanelImgList.Controls)
            {
                res.Add(ptrb.Image);
            }
            return res;
        }
        
        private void mixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //brdImage.DrawBoard(GameFunction.Mix(GetListImageFromCurrentListPtrb(), numberOfCol * numberOfRow), this, imgList[0].Size);
            BoardManager.imgBoard.DrawBoard(GameFunction.Mix(GetListImageFromCurrentListPtrb(), numberOfCol * numberOfRow), this, imgList[0].Size);
        }

        [Obsolete]
        private void chooseLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameFunction.ChooseLevel(numberOfCol);
            GameFunction.closeChooseLevelEvent += FncGame_closeChooseLevelEvent;
        }

        [Obsolete]
        private void FncGame_closeChooseLevelEvent(object sender, OnCloseChooseLevelFormEvent e)
        {
            currentLevel = int.Parse(e.Level);
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            UpdateRecordTable(currentLevel);
            levelCbx.Text = currentLevel.ToString();
            Start();
            GameFunction.closeChooseLevelEvent -= FncGame_closeChooseLevelEvent;
        }

        
        [Obsolete]
        private void chooseImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameFunction.ChooseImage();
            GameFunction.closeChooseImageEvent += FncGame_closeChooseImageEvent;
        }

        [Obsolete]
        private void FncGame_closeChooseImageEvent(object sender, OnCloseChooseImageFormEvent e)
        {
            img = e.Img;
            OriginPtrb.Image = new Bitmap(img, resizedImg);
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            Start();
            GameFunction.closeChooseImageEvent -= FncGame_closeChooseImageEvent;
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
            GameFunction.PowerModify(powerGrpBox);
            GameFunction.closePowerFormWhenPressCancelEvent += FncGame_closePowerFormWhenPressCancelEvent;
            GameFunction.closePowerFormWhenPressStartEvent += FncGame_closePowerFormWhenPressStartEvent;
            GameFunction.closePowerFormWhenClosingEvent += FncGame_closePowerFormWhenClosingEvent;

        }

        private void FncGame_closePowerFormWhenClosingEvent(object sender, OnClosePowerModifierFormEvent e)
        {
            powerGrpBox.Visible = e.IsDisplay;
        }

        [Obsolete]
        private void FncGame_closePowerFormWhenPressCancelEvent(object sender, OnClosePowerModifierFormEvent e)
        {
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
        }

        private void FncGame_closePowerFormWhenPressStartEvent(object sender, OnClosePowerModifierFormEvent e)
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

        public List<Image> CropIntoListImgs(int NumberOfRowBoard, int NumberOfColBoard, Bitmap ImgSource, int Width, int Height)
        {
            List<Image> imgs = new List<Image>();
            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    var img = new Bitmap(Width / NumberOfRowBoard, Height / NumberOfColBoard);
                    using (var grp = Graphics.FromImage(img))
                    {
                        grp.DrawImage(ImgSource, new Rectangle(0, 0, Width / NumberOfRowBoard, Height / NumberOfColBoard), new Rectangle(j * Width / NumberOfRowBoard, i * Height / NumberOfColBoard, Width / NumberOfRowBoard, Height / NumberOfColBoard), GraphicsUnit.Pixel);
                    }
                    imgs.Add(img);
                }
            }
            return imgs;
        }

        private void levelCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            UpdateRecordTable(int.Parse(cbx.Text));
        }
    }
}
