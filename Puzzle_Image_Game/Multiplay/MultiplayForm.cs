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
    public partial class MultiplayForm : Form, ICropImage
    {

        private bool isDisconnected;
        private int widthBoard = 270;
        private int heightBoard = 270;
        private Size resizedImg;
        private string path;
        private static int currentLevel = 3;
        private bool isWin = false;

        private int numberOfRow = CurrentLevel;
        private int numberOfCol = CurrentLevel;
        private bool isClient;
        private Image img;
        private List<Image> imgListServer;
        private List<Image> imgListClient;
        private SocketManager socket;
        private BoardManager clientBoard;
        private BoardManager serverBoard;
        private MultiplayManager multiplayManager;
        private Size sizeOfPtrb;

        public List<Image> ImgListServer { get => imgListServer; set => imgListServer = value; }
        public List<Image> ImgListClient { get => imgListClient; set => imgListClient = value; }
        public string Path { get => path; set => path = value; }
        public int NumberOfRow { get => numberOfRow; set => numberOfRow = value; }
        public int NumberOfCol { get => numberOfCol; set => numberOfCol = value; }
        public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public int WidthBoard { get => widthBoard; set => widthBoard = value; }
        public int HeightBoard { get => heightBoard; set => heightBoard = value; }
        public Image Img { get => img; set => img = value; }
        public BoardManager ClientBoard { get => clientBoard; set => clientBoard = value; }
        public BoardManager ServerBoard { get => serverBoard; set => serverBoard = value; }
        public bool IsWin { get => isWin; set => isWin = value; }
        public bool IsDisconnected { get => isDisconnected; set => isDisconnected = value; }

        [Obsolete]
        public MultiplayForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        [Obsolete]
        public MultiplayForm(SocketManager socket, bool isClient)
        {
            InitializeComponent();
            this.socket = socket;
            this.isClient = isClient;
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void MultiplayForm_Load(object sender, EventArgs e)
        {
            currentLevel = 3;
            Path = @"1.jpg";
            Img = Image.FromFile(Path);
            lbClientPlayer.Text = socket.PlayerName;
            imgListServer = new List<Image>(CropIntoListImgs(NumberOfRow, NumberOfCol,
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard));
            imgListClient = new List<Image>(CropIntoListImgs(NumberOfRow, NumberOfCol,
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard));
                        
            ClientBoard = new BoardManager(NumberOfRow, NumberOfCol, WidthBoard, HeightBoard,
                new Point(this.Width / 14, this.Height / 10),
                new Point(this.Width / 14, this.Height / 10 + 300), imgListClient);
            ClientBoard.OnFilledPictureBox += BoardManager_OnFilledPictureBox;
            ServerBoard = new BoardManager(NumberOfRow, NumberOfCol, WidthBoard, HeightBoard,
                new Point(this.Width - WidthBoard * 3 / 2, this.Height / 10),
                new Point(this.Width - WidthBoard * 3 / 2, this.Height / 10 + 300), imgListServer);

            resizedImg = new Size(WidthBoard, HeightBoard);
            
            Start();
            
            if (isClient)
            {
                chooseImgBtn.Enabled = mixBtn.Enabled = true;
                label1.Text = "Client";
                multiplayManager = new MultiplayManager(ClientBoard, ServerBoard, socket, this);
                multiplayManager.Start();
                socket.Send(new MultiplayableData(ClientBoard.imgBoard.Imgs,
                    new PlayerInfo(lbClientPlayer.Text, 0, "00:00:00")));
            }
            else
            {
                label1.Text = "Server at " + SocketManager.port;
                socket.OnClientConnected += Socket_OnClientConnected;
                chooseLvBtn.Visible = true;
                startBtn.Visible = true;
            }
            GameFunction.TimeEndEvent += GameFunction_TimeEndEvent;
            Img.Dispose();
        }

        //Event khi client kết nối
        private void Socket_OnClientConnected(object sender, EventArgs e)
        {
            chooseLvBtn.Enabled = chooseImgBtn.Enabled = mixBtn.Enabled = startBtn.Enabled = true;
            socket = sender as SocketManager;
            multiplayManager = new MultiplayManager(ClientBoard, ServerBoard, socket, this);
            multiplayManager.Start();
            socket.Send(new MultiplayableData(ClientBoard.imgBoard.Imgs,
                new PlayerInfo(lbClientPlayer.Text,0,"00:00:00")));
            socket.OnClientConnected -= Socket_OnClientConnected;
        }
        //Check Win
        private void BoardManager_OnFilledPictureBox(object sender, OnFilledImageInBlankBoardEvent e)
        {
            if (GameFunction.IsWin(e.PtrbList, NumberOfCol * NumberOfRow, ImgListClient))
            {
                IsWin = true;
                string elapsedTime = GameFunction.TimeElapse(lbHour.Text,
                    lbMinute.Text, lbSecond.Text, currentLevel);
                clientPlayerResultLb.Text = $"Completed! Your elapsed time: {elapsedTime}";
                int score = int.Parse(lbClientPlayerScore.Text) + 
                    GameFunction.ConvertTimeToSecond($"00:{currentLevel}:00")
                    - GameFunction.ConvertTimeToSecond(elapsedTime);
                lbClientPlayerScore.Text = score.ToString();
                PlayerInfo player = new PlayerInfo(lbClientPlayer.Text, score, elapsedTime);
                socket.Send(new MultiplayableData(player, IsWin));
                DisablePtrbs(clientBoard);

            } 
        }

        private void SetAttribute(BoardManager boardManager, List<Image> imgList)
        {

            boardManager.imgBoard.Imgs = GameFunction.Mix(imgList);

            boardManager.blankBoard.NumberOfRowBoard = NumberOfRow;
            boardManager.blankBoard.NumberOfColBoard = NumberOfCol;
            boardManager.imgBoard.NumberOfRowBoard = NumberOfRow;
            boardManager.imgBoard.NumberOfColBoard = NumberOfCol;

            boardManager.StartDraw(this, sizeOfPtrb);
        }

        public void DisablePtrbs(BoardManager boardManager)
        {
            int size = boardManager.imgBoard.PanelImgList.Controls.Count;
            for (int i = 0; i < size; i++)
            {
                boardManager.imgBoard.PanelImgList.Controls[i].Enabled = false;
                boardManager.blankBoard.PanelBlank.Controls[i].Enabled = false;
            }
        }

        public void ReleasePtrbs()
        {
            int size = clientBoard.imgBoard.PanelImgList.Controls.Count;
            for(int i = 0; i < size; i++)
            {
                clientBoard.imgBoard.PanelImgList.Controls[i].Enabled = true;
                clientBoard.blankBoard.PanelBlank.Controls[i].Enabled = true;
            }
        }
        
        public void Start()
        {
            Img = Image.FromFile(path);
            NumberOfRow = NumberOfCol = CurrentLevel;

            imgListServer = CropIntoListImgs(NumberOfRow, NumberOfCol,
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard);
            imgListClient = CropIntoListImgs(NumberOfRow, NumberOfCol,
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard);

            sizeOfPtrb = imgListClient[0].Size;
            OriginPtrb.Image = new Bitmap(Img, resizedImg);

            SetAttribute(ClientBoard, imgListClient);
            SetAttribute(ServerBoard, imgListServer);

            DisablePtrbs(ServerBoard);
            DisablePtrbs(clientBoard);

            img.Dispose();
        }

        public List<Image> CropIntoListImgs(int NumberOfRowBoard, int NumberOfColBoard, Bitmap ImgSource, int Width, int Height)
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
                        grp.DrawImage(ImgSource, new Rectangle(0, 0, Width / NumberOfRowBoard, Height / NumberOfColBoard), new Rectangle(j * Width / NumberOfRowBoard, i * Height / NumberOfColBoard, Width / NumberOfRowBoard, Height / NumberOfColBoard), GraphicsUnit.Pixel);
                    }
                    img.Tag = index.ToString();
                    imgs.Add(img);
                }
            }
            return imgs;
        }

        private List<Image> GetListImageFromCurrentListPtrb()
        {
            List<Image> res = new List<Image>();
            foreach (PictureBox ptrb in ClientBoard.imgBoard.PanelImgList.Controls)
            {
                res.Add(ptrb.Image);
            }
            return res;
        }

        //Mix
        private void mixBtn_Click(object sender, EventArgs e)
        {
            socket.Send(new MultiplayableData(true, $"{lbClientPlayer.Text} is mixing..."));
            mixBtn.Enabled = chooseImgBtn.Enabled = chooseLvBtn.Enabled = startBtn.Enabled = false;

            ClientBoard.imgBoard.Imgs = GameFunction.Mix(GetListImageFromCurrentListPtrb());
            sizeOfPtrb = ClientBoard.imgBoard.Imgs[0].Size;
            ClientBoard.StartDraw(this, sizeOfPtrb);
            socket.Send(new MultiplayableData(ClientBoard.imgBoard.Imgs));
            multiplayManager.SetEventToPtrb();
            DisablePtrbs(clientBoard);
        }
        //End Mix

        //Choose image
        private void chooseImgBtn_Click(object sender, EventArgs e)
        {
            socket.Send(new MultiplayableData(true, $"{lbClientPlayer.Text} is choosing image..."));
            startBtn.Enabled = mixBtn.Enabled = chooseLvBtn.Enabled = false;
            GameFunction.ChooseImage();
            GameFunction.ChooseImgForm.closeChooseImgForm += ChooseImgForm_closeChooseImageEvent;
        }

        private void ProcessWhenChooseImage()
        {
            
            NumberOfRow = NumberOfCol = CurrentLevel;
            ImgListClient = CropIntoListImgs(NumberOfRow, NumberOfCol, 
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard);
            OriginPtrb.Image = new Bitmap(Img, resizedImg);
            sizeOfPtrb = imgListClient[0].Size;
            SetAttribute(ClientBoard, ImgListClient);
            
        }

        private void ChooseImgForm_closeChooseImageEvent(object sender, OnCloseChooseImageFormEvent e)
        {
            Path = e.Path;
            Img = Image.FromFile(Path);
            ProcessWhenChooseImage();
            socket.Send(new MultiplayableData(ClientBoard.imgBoard.Imgs));
            multiplayManager.SetEventToPtrb();
            Img.Dispose();
            GameFunction.ChooseImgForm.closeChooseImgForm -= ChooseImgForm_closeChooseImageEvent;
        }
        //end choose image

        //Choose level
        private void chooseLvBtn_Click(object sender, EventArgs e)
        {
            socket.Send(new MultiplayableData(true, 
                $"{lbClientPlayer.Text} is choosing level..."));
            chooseImgBtn.Enabled = mixBtn.Enabled = startBtn.Enabled = false;
            GameFunction.ChooseLevel(CurrentLevel);
            GameFunction.ChooseLvForm.CloseLevelFormEvent 
                += ChooseLvForm_closeChooseLevelEvent;
        }

        private void ProcessWhenChooseLevel()
        {
            lbHour.Text = GameFunction.HandleTime(0);
            lbMinute.Text = GameFunction.HandleTime(CurrentLevel);
            lbSecond.Text = GameFunction.HandleTime(0);

            NumberOfRow = NumberOfCol = CurrentLevel;

            imgListClient = CropIntoListImgs(NumberOfRow, NumberOfCol, 
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard);
            imgListServer = CropIntoListImgs(NumberOfRow, NumberOfCol, 
                new Bitmap(Img, WidthBoard, HeightBoard), WidthBoard, HeightBoard);

            sizeOfPtrb = imgListClient[0].Size;
            OriginPtrb.Image = new Bitmap(Img, resizedImg);

            SetAttribute(ClientBoard, imgListClient);
            SetAttribute(ServerBoard, imgListServer);
        }

        private void ChooseLvForm_closeChooseLevelEvent(object sender, OnCloseChooseLevelFormEvent e)
        {
            CurrentLevel = int.Parse(e.Level);
                
            clientPlayerResultLb.Text = "";
            serverPlayerResultLb.Text = "";

            Img = Image.FromFile(path);
            ProcessWhenChooseLevel();
            socket.Send(new MultiplayableData(ClientBoard.imgBoard.Imgs, ServerBoard.imgBoard.Imgs,
                CurrentLevel, new Bitmap(Img, WidthBoard, HeightBoard), ImgListClient,
                ImgListServer, lbHour.Text, lbMinute.Text, lbSecond.Text));
            multiplayManager.SetEventToPtrb();
            

            DisablePtrbs(clientBoard);
            DisablePtrbs(serverBoard);

            img.Dispose();
            GameFunction.ChooseLvForm.CloseLevelFormEvent -= ChooseLvForm_closeChooseLevelEvent;

        }
        //End choose level

        private void MultiplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!socket.Client.Client.Connected) {
               
                socket.NetStream?.Close();
                socket.Client?.Close();
                socket.SkForm.Close();
                return;
            }

            bool flag = false;
            if (!IsDisconnected && MessageBox.Show("Tiến trình hiện tại của bạn sẽ" +
                " không được lưu","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning)
                == DialogResult.OK) {
                socket.Send(new MultiplayableData("disconnected"));
                flag = true;
            }
            
            if(!flag) socket.Send(new MultiplayableData("disconnected"));
            if (socket.Client.Client.Connected)
            {
                socket.Client.GetStream().Close();
                socket.Client.Close();
            }
            socket.SkForm.Close();
        }
        //Nhấn start
        private void startBtn_Click(object sender, EventArgs e)
        {
            IsWin = false;
            ReleasePtrbs();
            chooseLvBtn.Enabled = chooseImgBtn.Enabled = mixBtn.Enabled = startBtn.Enabled = false;
            socket.Send(new MultiplayableData(true));
            GameFunction.TimeCount(lbHour, lbMinute, lbSecond, false);
        }

        private void GameFunction_TimeEndEvent(object sender, EventArgs e)
        {
            if (IsWin) return;
            PlayerInfo player = new PlayerInfo(lbClientPlayer.Text, 0, 
                $"00:{GameFunction.HandleTime(currentLevel)}:00");
            socket.Send(new MultiplayableData(player, false));
            DisablePtrbs(clientBoard);
            clientPlayerResultLb.Text = $"Oh no! Poor you :(((,\nYour elapsed time" +
                $": 00:{GameFunction.HandleTime(currentLevel)}:00";
        }

        [Obsolete]
        private void Label_TextChanged(object sender, EventArgs e)
        {
            if(clientPlayerResultLb.Text == "" || serverPlayerResultLb.Text == "")
            {
                return;
            }
            chooseLvBtn.Enabled = true;

            if (lbHour.Text == "00" && lbMinute.Text == "00" && lbSecond.Text == "00") return;

            GameFunction.StopThreads(GameFunction.ThreadCountDown);
        }
        //end start

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string msg = "Đây là chế độ chơi 2 người qua mạng LAN\nVì không có kinh nghiệm" +
                " lập trình Socket\nnên có thể phát sinh nhiều lỗi thiếu xót.\n\n Trò chơi " +
                "sẽ tính điểm dựa trên thời gian bạn hoàn thành\nHoàn thành càng sớm điểm càng cao.";
            MessageBox.Show(msg, "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
