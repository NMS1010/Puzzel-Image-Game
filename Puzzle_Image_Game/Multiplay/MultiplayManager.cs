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
    public class MultiplayManager
    {
        private BoardManager client;
        private BoardManager server;
        private MultiplayableData dataSend;
        private SocketManager socket;
        private List<PictureBox> ptrbs;
        private MultiplayForm fm;

        public MultiplayManager(BoardManager client, BoardManager server, SocketManager socket, MultiplayForm fm)
        {
            Client = client;
            Server = server;
            dataSend = new MultiplayableData();
            this.fm = fm;
            this.socket = socket;
        }

        internal BoardManager Client { get => client; set => client = value; }
        internal BoardManager Server { get => server; set => server = value; }

        public void GetAllPtrb(BoardManager boardManager)
        {
            ptrbs = new List<PictureBox>();
            foreach(PictureBox item in boardManager.blankBoard.PanelBlank.Controls)
            {
                ptrbs.Add(item);
            }
            foreach (PictureBox item in boardManager.imgBoard.PanelImgList.Controls)
            {
                ptrbs.Add(item);
            }
        }

        private void AddEventToEachPtrb(Panel panel)
        {
            foreach(PictureBox ptrb in panel.Controls)
            {
                ptrb.DragDrop += Ptrb_DragDrop;
                ptrb.MouseDown += Ptrb_MouseDown;
            }
        }

        private void Ptrb_MouseDown(object sender, MouseEventArgs e)
        {
            var ptrb = sender as PictureBox;
            dataSend.SrcPos = int.Parse(ptrb.Tag.ToString());
            dataSend.InitialImgs = null;
            socket.Send(dataSend);
        }

        private void Ptrb_DragDrop(object sender, DragEventArgs e)
        {
            var ptrb = sender as PictureBox;
            var img = e.Data.GetData(DataFormats.Bitmap) as Bitmap;
            
            dataSend.DesImg = img;
            dataSend.DesPos = int.Parse(ptrb.Tag.ToString());
            dataSend.SrcImg = client.HoldImg;
        }

        private void UpdateBoard( MultiplayableData dataReceive)
        {
            int size = ptrbs.Count;
            for(int i = 0; i < size; i++)
            {
                if(ptrbs[i].Tag.ToString() == dataReceive.SrcPos.ToString())
                {
                    ptrbs[i].Image = dataReceive.SrcImg;
                }
                if(ptrbs[i].Tag.ToString() == dataReceive.DesPos.ToString())
                {
                    ptrbs[i].Image = dataReceive.DesImg;
                }
            }
            
        }

        public void SetEventToPtrb()
        {
            GetAllPtrb(server);

            AddEventToEachPtrb(Client.blankBoard.PanelBlank);
            AddEventToEachPtrb(Client.imgBoard.PanelImgList);
        }

        public void Start()
        {
            SetEventToPtrb();
            ListenDataReceived();
        }

        private void UpdateLevel(BoardManager boardManager, List<Image> imgList)
        {
            boardManager.imgBoard.Imgs = imgList;
            boardManager.imgBoard.NumberOfColBoard = boardManager.
                imgBoard.NumberOfRowBoard = MultiplayForm.CurrentLevel;
            boardManager.blankBoard.NumberOfColBoard = boardManager.
                blankBoard.NumberOfRowBoard = MultiplayForm.CurrentLevel;
            boardManager.StartDraw(fm, new Size(fm.WidthBoard/MultiplayForm.
                CurrentLevel, fm.HeightBoard / MultiplayForm.CurrentLevel));
            
        }

        private void ListenDataReceived()
        {
            Thread t = new Thread(() => {
                loop:
                try
                {
                    MultiplayableData dataReceive = socket.Receive() as MultiplayableData;
                    if (dataReceive != null)
                    {

                        if (dataReceive.InitialImgs != null)
                        {
                            server.imgBoard.Imgs = dataReceive.InitialImgs;
                            if (dataReceive.Player != null)
                                fm.lbServerPlayer.Text = dataReceive.Player.Name;
                            server.StartDraw(fm, new Size(fm.WidthBoard / MultiplayForm.CurrentLevel,
                                fm.HeightBoard / MultiplayForm.CurrentLevel));
                            fm.DisablePtrbs(server);
                            fm.DisablePtrbs(client);
                            fm.mixBtn.Enabled = fm.chooseImgBtn.Enabled = fm.chooseLvBtn.Enabled = fm.startBtn.Enabled = true;
                            fm.statusLb.Text = "";
                            socket.Send(new MultiplayableData("completelyMix"));
                        }
                        else if (dataReceive.IsWin)
                        {
                            fm.lbServerPlayerScore.Text = dataReceive.Player.Score.ToString();
                            fm.serverPlayerResultLb.Text = $"Completed! {dataReceive.Player.Name}'s " +
                            $"elapsed time: {dataReceive.Player.ElaspedTime}";
                        }
                        else if (dataReceive.IsLose) {
                            fm.serverPlayerResultLb.Text = $"Oh no! Poor {dataReceive.Player.Name}'s" +
                            $" :(((,\n{dataReceive.Player.Name}'s elapsed time: {dataReceive.Player.ElaspedTime}";
                        }
                        else if (dataReceive.IsPressButton)
                        {
                            fm.mixBtn.Enabled = fm.chooseImgBtn.Enabled = 
                            fm.chooseLvBtn.Enabled = fm.startBtn.Enabled = false;
                            fm.statusLb.Text = dataReceive.Msg;
                        }
                        else if (dataReceive.IsPressStartBtn)
                        {
                            fm.chooseImgBtn.Enabled = fm.mixBtn.Enabled = false;
                            fm.ReleasePtrbs();
                            GameFunction.TimeCount(fm.lbHour, fm.lbMinute, fm.lbSecond, false);
                        }
                        else if(dataReceive.Status == "completelyChooseLevel")
                        {
                            fm.mixBtn.Enabled = fm.chooseImgBtn.Enabled = 
                            fm.chooseLvBtn.Enabled = fm.startBtn.Enabled = true;
                            fm.statusLb.Text = "";
                        }
                        else if(dataReceive.Status == "completelyMix")
                        {
                            fm.mixBtn.Enabled = fm.chooseImgBtn.Enabled =
                            fm.chooseLvBtn.Enabled = fm.startBtn.Enabled = true;
                            fm.statusLb.Text = "";
                        }
                        else if(dataReceive.Status == "disconnected")
                        {
                            if (socket.Client.Connected)
                            {
                                MessageBox.Show($"{fm.lbServerPlayer.Text} has disconnected! Press OK to exit",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                fm.IsDisconnected = true;
                                fm.Close();
                            }
                        }
                        else if (dataReceive.Level != 0)
                        {
                            fm.IsWin = false;

                            fm.statusLb.Text = "";

                            fm.NumberOfRow = fm.NumberOfCol = 
                            MultiplayForm.CurrentLevel = dataReceive.Level;

                            fm.clientPlayerResultLb.Text = "";
                            fm.serverPlayerResultLb.Text = "";


                            
                            fm.lbHour.Text = dataReceive.Hour;
                            fm.lbMinute.Text = dataReceive.Minute;
                            fm.lbSecond.Text = dataReceive.Second;

                            fm.ImgListClient = dataReceive.InitialImgsListClient;
                            fm.ImgListServer = dataReceive.InitialImgsListServer;
                            fm.OriginPtrb.Image = dataReceive.Img;
                            UpdateLevel(client, dataReceive.MixedImgsServer);

                            UpdateLevel(server, dataReceive.MixedImgsClient);
                            fm.DisablePtrbs(fm.ClientBoard);
                            fm.DisablePtrbs(server);
                            fm.mixBtn.Enabled = fm.chooseImgBtn.Enabled = true;
                            socket.Send(new MultiplayableData("completelyChooseLevel"));
                        }
                        else
                        {
                            UpdateBoard(dataReceive);
                        }
                        SetEventToPtrb();
                    }
                    goto loop;
                }
                catch
                {
                    return;
                }
            
            });
            t.IsBackground = true;
            t.Start();
        }
        
        
    }
}
