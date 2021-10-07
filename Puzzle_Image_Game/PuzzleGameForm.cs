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
        private int numberOfRow = 3;
        private int numberOfCol = 3;
        private List<Image> imgList;
        private BlankBoard brdBlank;
        private ImageBoard brdImage;
        private CropImg crpImg;
        private FunctionInGame fncGame;
        private Thread t;

        public PuzzleGameForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        
        private void Start()
        {
            crpImg = new CropImg(numberOfRow, numberOfCol, resizedImg, path);
            imgList = crpImg.CropIntoListImgs();
            brdBlank.NumberOfColBoard = numberOfCol;
            brdBlank.NumberOfRowBoard = numberOfRow;
            brdImage.NumberOfColBoard = numberOfCol;
            brdImage.NumberOfRowBoard = numberOfRow;
            brdImage.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
            brdBlank.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
        }
        private void Brd_OnFilledPictureBox(object sender, FilledPictureBoxEventArgs e)
        {
            if (fncGame.IsWin(e.PtrbList, numberOfCol * numberOfRow, imgList))
            {
                MessageBox.Show("Win");
            }
        }

        private  void mergeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            brdBlank.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
            brdImage.DrawBoard(fncGame.Mix(imgList, numberOfCol * numberOfRow), this);
        }
        private bool flagLevel = true;
        private void chooseLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fncGame.ChooseLevel(numberOfCol);
            
            if (flagLevel)
            {
                fncGame.closeChooseLevelEvent += FncGame_closeChooseLevelEvent;
                flagLevel = false;
            }
        }

        private void FncGame_closeChooseLevelEvent(object sender, CloseChooseLevelFormEvent e)
        {
            numberOfRow = numberOfCol = Convert.ToInt32(e.Level);
            Start();
        }
        private bool flagImg = true;
        private void chooseImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fncGame.ChooseImage();
            if (flagImg)
            {
                fncGame.closeChooseImageEvent += FncGame_closeChooseImageEvent;
                flagImg = false;
            }
        }

        private void FncGame_closeChooseImageEvent(object sender, CloseChooseImageFormEvent e)
        {
            path = e.ImgPath;
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            Start();
        }

        private void PuzzleGameForm_Load(object sender, EventArgs e)
        {
            path = @"1.jpg";
            List<Image> imgList = new List<Image>();
            fncGame = new FunctionInGame();
            resizedImg = new Size(width, height);
            brdBlank = new BlankBoard(numberOfRow, numberOfCol, width, height);
            brdImage = new ImageBoard(numberOfRow, numberOfCol, width, height, brdBlank);
            
            OriginPtrb.Image = new Bitmap(Image.FromFile(path), resizedImg);
            brdImage.OnFilledPictureBox += Brd_OnFilledPictureBox;
            brdBlank.OnFilledPictureBox += Brd_OnFilledPictureBox;
            Start();
        }

        private void powerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fncGame.PowerModify();
        }
    }
}
