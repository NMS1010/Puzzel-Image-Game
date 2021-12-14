using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Puzzle_Image_Game
{
    public partial class PuzzleGameForm : Form, ICropImage
    {
        private InitialGameForm startFm;

        private int width = 270;
        private int height = 270;
        private Size resizedImg;
        private string path;
        private static int currentLevel;
        private int maxLevel = 10;
        private int numberOfRow = currentLevel;
        private int numberOfCol = currentLevel;
        private Image img;
        private List<Image> imgList;
        private BoardManager boardManager;
        private List<List<int>> records;

        [Obsolete]
        public PuzzleGameForm(InitialGameForm startFm)
        {
            InitializeComponent();
            this.startFm = startFm;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        [Obsolete]
        private void PuzzleGameForm_Load(object sender, EventArgs e)
        {
            currentLevel = 3;
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

            boardManager = new BoardManager(numberOfRow, numberOfCol, width, height,
                new Point(this.Width / 12, this.Height / 10), new Point(this.Width - width * 3 / 2, this.Height / 10)
                , CropIntoListImgs(numberOfRow, numberOfCol, new Bitmap(img, width, height), width, height));
            img.Dispose();
            resizedImg = new Size(width, height);
            boardManager.OnFilledPictureBox += Brd_OnFilledImageInBlankBoardEvent;
            Start();
        }

        private void UpdateRecordTable(int level)
        {
            int i = 0;
            int number = 1;
            foreach(Label item in recordPanel.Controls)
            {
                if(records[level - 3][i] != int.MaxValue)
                {
                    item.Text = $"{number}. " + GameFunction.ConvertSecondToTime(records[level - 3][i]);
                    number++;
                }
                else
                    item.Text = "";
                i++;
            }
        }
        private void Start()
        {
            img = Image.FromFile(path);
            numberOfRow = numberOfCol = currentLevel;
            imgList = CropIntoListImgs(numberOfRow, numberOfCol, new Bitmap(img,width,height),width,height);
            OriginPtrb.Image = new Bitmap(img, resizedImg);
            boardManager.imgBoard.Imgs = GameFunction.Mix(imgList);

            boardManager.blankBoard.NumberOfRowBoard = numberOfRow;
            boardManager.blankBoard.NumberOfColBoard = numberOfCol;
            boardManager.imgBoard.NumberOfRowBoard = numberOfRow;
            boardManager.imgBoard.NumberOfColBoard = numberOfCol;

            lbMinute.Text = GameFunction.HandleTime(currentLevel);
            lbSecond.Text = "00";
            lbHour.Text = "00";

            boardManager.StartDraw(this, imgList[0].Size);
            boardManager.OnClickPictureBox += BrdImage_OnClickPictureBox;
            img.Dispose();
        }

        private void BrdImage_OnClickPictureBox(object sender, EventArgs e)
        {
            GameFunction.TimeCount(lbHour, lbMinute, lbSecond,false);
            GameFunction.TimeEndEvent += CountDownTimeEvent;
            boardManager.OnClickPictureBox -= BrdImage_OnClickPictureBox;
        }

        [Obsolete]
        private void Brd_OnFilledImageInBlankBoardEvent(object sender,
            OnFilledImageInBlankBoardEvent e)
        {
            if (GameFunction.IsWin(e.PtrbList, numberOfCol * numberOfRow, imgList))
            {
                GameFunction.StopThreads(GameFunction.ThreadCountDown);
                string time = GameFunction.TimeElapse(lbHour.Text,
                    lbMinute.Text, lbSecond.Text,currentLevel);
                records[currentLevel-3].Add(GameFunction.ConvertTimeToSecond(time));
                records[currentLevel-3].Sort();
                records[currentLevel-3].RemoveRange(3, records[currentLevel-3].Count - 3);
                UpdateRecordTable(currentLevel);
                if (MessageBox.Show($"Great! You won\nTime elapse: {time}\nClick OK to" +
                    $" go to next challenge\nClick Cancel to play again","Result",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    currentLevel += 1;
                }
                if (currentLevel > 10)
                {
                    MessageBox.Show("There is no challenge for you! Congratulation!");
                    currentLevel = 10;
                }
                levelCbx.Text = currentLevel.ToString();
                Start();
            }
        }

        private List<Image> GetListImageFromCurrentListPtrb()
        {
            List<Image> res = new List<Image>();
            foreach(PictureBox ptrb in boardManager.imgBoard.PanelImgList.Controls)
            {
                res.Add(ptrb.Image);
            }
            return res;
        }
        
        private void mixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            boardManager.imgBoard.Imgs = GameFunction.Mix(GetListImageFromCurrentListPtrb());
            boardManager.imgBoard.DrawBoard( this, imgList[0].Size, boardManager);
        }

        [Obsolete]
        private void chooseLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameFunction.ChooseLevel(numberOfCol);
            GameFunction.ChooseLvForm.CloseLevelFormEvent += ChooseLvForm_closeChooseLevelEvent;
        }

        [Obsolete]
        private void ChooseLvForm_closeChooseLevelEvent(object sender, OnCloseChooseLevelFormEvent e)
        {
            currentLevel = int.Parse(e.Level);
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            UpdateRecordTable(currentLevel);
            levelCbx.Text = currentLevel.ToString();
            Start();
            GameFunction.ChooseLvForm.CloseLevelFormEvent -= ChooseLvForm_closeChooseLevelEvent;
        }

        [Obsolete]
        private void chooseImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameFunction.ChooseImage();
            GameFunction.ChooseImgForm.closeChooseImgForm += ChooseImgForm_closeChooseImageEvent;
        }

        [Obsolete]
        private void ChooseImgForm_closeChooseImageEvent(object sender, OnCloseChooseImageFormEvent e)
        {
            path = e.Path;
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            Start();
            GameFunction.ChooseImgForm.closeChooseImgForm -= ChooseImgForm_closeChooseImageEvent;
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
            GameFunction.PowerFm.HandleTimeWhenPressCancel += PowerFm_closePowerFormWhenPressCancelEvent;
            GameFunction.PowerFm.HandleTimeWhenPressStart += PowerFm_closePowerFormWhenPressStartEvent;
            GameFunction.PowerFm.HandleTimeWhenClosing += PowerFm_closePowerFormWhenClosingEvent;

        }

        private void PowerFm_closePowerFormWhenClosingEvent(
            object sender, OnClosePowerModifierFormEvent e)
        {
            powerGrpBox.Visible = e.IsDisplay;
            GameFunction.PowerFm.HandleTimeWhenClosing
                -= PowerFm_closePowerFormWhenClosingEvent;
        }

        [Obsolete]
        private void PowerFm_closePowerFormWhenPressCancelEvent(
            object sender, OnClosePowerModifierFormEvent e)
        {
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
            GameFunction.PowerFm.HandleTimeWhenPressCancel
                -= PowerFm_closePowerFormWhenPressCancelEvent;
        }

        private void PowerFm_closePowerFormWhenPressStartEvent(
            object sender, OnClosePowerModifierFormEvent e)
        {
            lbTxt.Text = $"    Your PC will\n {e.Mode.ToLower()} in about: ";
            lbH.Text = e.Hour;
            lbM.Text = e.Minute;
            lbS.Text = e.Second;
            lbNotation1.Text = ":";
            lbNotation2.Text = ":";
            GameFunction.TimeCount(lbH, lbM, lbS,true);
            GameFunction.PowerFm.HandleTimeWhenPressStart
                -= PowerFm_closePowerFormWhenPressStartEvent;
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
                if (MessageBox.Show("Bạn thua rồi\nBạn có muốn chơi lại?"
                    , "Result", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Start();
                }
            }
            GameFunction.TimeEndEvent -= CountDownTimeEvent;
        }

        public List<Image> CropIntoListImgs(int NumberOfRowBoard, int NumberOfColBoard,
            Bitmap ImgSource, int Width, int Height)
        {
            List<Image> imgs = new List<Image>();
            int index = 0;
            for (int i = 0; i < NumberOfRowBoard; i++)
            {
                for (int j = 0; j < NumberOfColBoard; j++)
                {
                    var img = new Bitmap(Width / NumberOfRowBoard, Height / NumberOfColBoard);
                    using (var grp = Graphics.FromImage(img))
                    {
                        grp.DrawImage(ImgSource, new Rectangle(0, 0, Width / NumberOfRowBoard,
                            Height / NumberOfColBoard), new Rectangle(j * Width / NumberOfRowBoard,
                            i * Height / NumberOfColBoard, Width / NumberOfRowBoard,
                            Height / NumberOfColBoard), GraphicsUnit.Pixel);
                    }
                    img.Tag = index.ToString();
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

        [Obsolete]
        private void PuzzleGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            GameFunction.StopThreads(GameFunction.ThreadCountDown);
            GameFunction.StopThreads(GameFunction.ThreadsOfPowerForm);
            powerGrpBox.Visible = false;
            GameFunction.isPowerStartClicked = false;
            
            startFm.Show();
            GameFunction.ChooseImgForm?.Dispose();
            GameFunction.MusicPlayerForm?.Dispose();
            GameFunction.PowerFm?.Dispose();
            GameFunction.ChooseLvForm?.Dispose();
            Dispose();
        }


        #region: Music Player
        private bool isPressRepeatBtn = false;
        private void repeatBtn_Click(object sender, EventArgs e)
        {
            if (!isPressRepeatBtn)
                repeatBtn.BackColor = Color.FromArgb(128, 255, 128);
            else
                repeatBtn.BackColor = Color.FromArgb(255, 192, 192);
            isPressRepeatBtn = !isPressRepeatBtn;

        }

        
        private void musicPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameFunction.MusicPlayer();
            GameFunction.MusicPlayerForm.OnPressPlayButtonMusicPlayer 
                += MusicPlayerForm_OnPressPlayButtonMusicPlayer;
            GameFunction.MusicPlayerForm.OnEndedMusic 
                += MusicPlayerForm_OnEndedMusic;
        }

        private void MusicPlayerForm_OnEndedMusic(object sender, EventArgs e)
        {
            timePlayNextSong.Enabled = true;
            GameFunction.MusicPlayerForm.OnEndedMusic -= MusicPlayerForm_OnEndedMusic;

        }
        private void timePlayNextSong_Tick(object sender, EventArgs e)
        {
            timePlayNextSong.Enabled = false;
            int index = GameFunction.MusicPlayerForm.MusicPlayerManager.IndexSongPlaying;
            if (isPressRepeatBtn)
            {
                UpdataMusic(index);
            }
            else
            {
                UpdataMusic(index + 1 < GameFunction.MusicPlayerForm.MusicPlayerManager.Songs.Count ? index + 1 : 0);
            }
            
        }
        private void MusicPlayerForm_OnPressPlayButtonMusicPlayer(object sender,
            Events.OnPressPlayButtonMusicPlayer e)
        {
            musicplayerPnl.Visible = true;
            playBtn.Visible = false;
            pauseBtn.Visible = true;
            songLbl.Text = e.Name;
            GameFunction.MusicPlayerForm.OnPressPlayButtonMusicPlayer
                -= MusicPlayerForm_OnPressPlayButtonMusicPlayer;
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            pauseBtn.Visible = false;
            playBtn.Visible = true;
            GameFunction.MusicPlayerForm.WMPlayer.Ctlcontrols.pause();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            pauseBtn.Visible = true;
            playBtn.Visible = false;
            GameFunction.MusicPlayerForm.WMPlayer.Ctlcontrols.play();
        }

        private void UpdataMusic(int index)
        {
            GameFunction.MusicPlayerForm.WMPlayer.URL = 
                Path.GetFullPath(GameFunction.MusicPlayerForm.MusicPlayerManager.Songs[index].Path);
            GameFunction.MusicPlayerForm.MusicPlayerManager.SongPlaying =
                GameFunction.MusicPlayerForm.MusicPlayerManager.Songs[index].Path;
            GameFunction.MusicPlayerForm.MusicPlayerManager.IndexSongPlaying = index;
            songLbl.Text = Path.GetFileNameWithoutExtension(GameFunction.MusicPlayerForm.MusicPlayerManager.Songs[index].Name);
            pauseBtn.Visible = true;
            playBtn.Visible = false;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            int index = GameFunction.MusicPlayerForm.MusicPlayerManager.IndexSongPlaying;
            int nextIndex = index + 1 < 
                GameFunction.MusicPlayerForm.MusicPlayerManager.Songs.Count ? index + 1 : 0;
            UpdataMusic(nextIndex);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            int index = GameFunction.MusicPlayerForm.MusicPlayerManager.IndexSongPlaying;
            int prevIndex = index - 1 < 0 ? 
                GameFunction.MusicPlayerForm.MusicPlayerManager.Songs.Count - 1 : index - 1;
            UpdataMusic(prevIndex);
        }
        #endregion

        
    }
}
