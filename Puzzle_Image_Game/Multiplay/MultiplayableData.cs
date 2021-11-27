using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    [Serializable]
    public class MultiplayableData
    {
        private Image desImg;
        private Image srcImg;
        private int desPos = -1;
        private int srcPos = -1;

        private List<Image> initialImgs;
        private List<Image> mixedImgsClient;
        private List<Image> mixedImgsServer;
        private List<Image> initialImgsListClient;
        private List<Image> initialImgsListServer;
        private Image img;

        private int level;
        private string hour;
        private string minute;
        private string second;

        private bool isPressButton;
        private string msg;

        private bool isPressStartBtn;
        private string status;
        private PlayerInfo player;
        private bool isWin;
        private bool isLose;

        //thông báo win/lose
        public MultiplayableData(PlayerInfo player, bool isWin)
        {
            Player = player;
            IsWin = isWin;
            IsLose = !isWin;
        }

        //Các status của cả 2 bên 
        public MultiplayableData(string status)
        {
            Status = status;
        }

        public MultiplayableData()
        {

        }
        //Khi server nhấn start
        public MultiplayableData(bool isPressStartBtn)
        {
            IsPressStartBtn = isPressStartBtn;
        }
        //Khi client hoặc server nhấn nút
        public MultiplayableData(bool isPressButton, string msg)
        {
            IsPressButton = isPressButton;
            Msg = msg;
        }

        
        //Khi server chọn level khác
        public MultiplayableData(List<Image> mixedImgsClient,
            List<Image> mixedImgsServer,int level,Image img, 
            List<Image> imgsListClient, List<Image> imgsListServer,
            string h, string m, string s)
        {
            MixedImgsClient = mixedImgsClient;
            MixedImgsServer = mixedImgsServer;
            Level = level;
            Img = img;
            InitialImgsListClient = imgsListClient;
            InitialImgsListServer = imgsListServer;
            Hour = h;
            Minute = m;
            Second = s;
        }
        //đồng bộ ảnh khi nhấn nút Mix
        public MultiplayableData(List<Image> imgs)
        {
            InitialImgs = imgs;
        }
        //Khởi tạo ban đầu để đồng bộ 2 phía
        public MultiplayableData(List<Image> imgs, PlayerInfo player)
        {
            InitialImgs = imgs;
            Player = player;
        }

        //Đồng bộ kéo thả giữa 2 phía
        public MultiplayableData(Image desImg, int desPos,
            Image srcImg, int srcPos)
        {
            DesImg = desImg;
            SrcImg = srcImg;
            DesPos = desPos;
            SrcPos = srcPos;
        }

        public Image DesImg { get => desImg; set => desImg = value; }
        public Image SrcImg { get => srcImg; set => srcImg = value; }
        public int DesPos { get => desPos; set => desPos = value; }
        public int SrcPos { get => srcPos; set => srcPos = value; }

        public Image Img { get => img; set => img = value; }
        public int Level { get => level; set => level = value; }
        public List<Image> InitialImgsListClient { get => initialImgsListClient; set => initialImgsListClient = value; }
        public List<Image> InitialImgsListServer { get => initialImgsListServer; set => initialImgsListServer = value; }
        public List<Image> MixedImgsClient { get => mixedImgsClient; set => mixedImgsClient = value; }
        public List<Image> MixedImgsServer { get => mixedImgsServer; set => mixedImgsServer = value; }
        public List<Image> InitialImgs { get => initialImgs; set => initialImgs = value; }
        public string Hour { get => hour; set => hour = value; }
        public string Minute { get => minute; set => minute = value; }
        public string Second { get => second; set => second = value; }
        public bool IsPressStartBtn { get => isPressStartBtn; set => isPressStartBtn = value; }
        public PlayerInfo Player { get => player; set => player = value; }
        public bool IsWin { get => isWin; set => isWin = value; }
        public bool IsLose { get => isLose; set => isLose = value; }
        public string Status { get => status; set => status = value; }
        public bool IsPressButton { get => isPressButton; set => isPressButton = value; }
        public string Msg { get => msg; set => msg = value; }
    }
}
