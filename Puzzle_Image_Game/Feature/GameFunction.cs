using Puzzle_Image_Game.Events;
using Puzzle_Image_Game.Feature.Music_Player;
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
    public static class GameFunction
    {
        public static event EventHandler<EventArgs> TimeEndEvent;

        private static ChooseLevelForm chooseLvForm;
        private static ChooseImageForm chooseImgForm;
        private static PowerModifierForm powerFm;
        

        private static MusicPlayerForm musicPlayerForm;
        

        private static List<Thread> threadsOfPowerForm;
        private static List<Thread> threadCountDown;

        static GameFunction()
        {
            ThreadsOfPowerForm = new List<Thread>();
            ThreadCountDown = new List<Thread>();
        }

        public static List<Thread> ThreadsOfPowerForm { get => threadsOfPowerForm; set => threadsOfPowerForm = value; }
        public static List<Thread> ThreadCountDown { get => threadCountDown; set => threadCountDown = value; }
        public static PowerModifierForm PowerFm { get => powerFm; set => powerFm = value; }
        public static ChooseImageForm ChooseImgForm { get => chooseImgForm; set => chooseImgForm = value; }
        public static ChooseLevelForm ChooseLvForm { get => chooseLvForm; set => chooseLvForm = value; }
        public static MusicPlayerForm MusicPlayerForm { get => musicPlayerForm; set => musicPlayerForm = value; }


        private static int RandomNotRepeat(List<int> nums, int max)
        {
            Random rand = new Random();
            int number;
            do
            {
                number = rand.Next(0, max);
            } while (nums.Contains(number));
            return number;
        }

        public static List<Image> Mix(List<Image> imgList)
        {
            List<Image> imgs = new List<Image>();
            List<Image> imgsNotNull = new List<Image>();
            List<Image> imgsTemp = new List<Image>();

            foreach (var item in imgList)
            {
                imgs.Add(item);
                if (item != null)
                {
                    imgsNotNull.Add(item);
                }
            }
            List<int> numbersRandom = new List<int>();

            int number;
            for(int i = 0; i < imgsNotNull.Count; i++)
            {
                number = RandomNotRepeat(numbersRandom, imgsNotNull.Count);
                numbersRandom.Add(number);
                imgsTemp.Add(imgsNotNull[number]);
            }
            int index = 0;
            for(int i = 0; i < imgList.Count; i++)
            {
                if (imgs[i] != null)
                {
                    imgs[i] = imgsTemp[index++];
                }
            }
            return imgs;
        }

        public static void ChooseLevel(int numberOfCol)
        {
            ChooseLvForm = new ChooseLevelForm(numberOfCol);
            if (Application.OpenForms[ChooseLvForm.Name] == null)
            {
                ChooseLvForm.Show();
            }
            else
            {
                Application.OpenForms[ChooseLvForm.Name].Focus();
            }
        }

        public static void MusicPlayer()
        {
            foreach(Form item in Application.OpenForms){
                if(item.Name == "MusicPlayerForm")
                {
                    MusicPlayerForm.Show();
                    MusicPlayerForm.Focus();
                    return;
                }
            }
            MusicPlayerForm = new Feature.Music_Player.MusicPlayerForm();
            MusicPlayerForm.Show();
            
        }


        public static void ChooseImage()
        {
            ChooseImgForm = new ChooseImageForm();
            
            if(Application.OpenForms[ChooseImgForm.Name] == null)
            {
                ChooseImgForm.Show();
            }
            else
            {
                Application.OpenForms[ChooseImgForm.Name].Focus();
            }
        }


        #region: time processing

        public static string HandleTime(int i)
        {
            return i >= 10 ? i.ToString() : "0" + i.ToString();
        }
        private static void Timer(ref int h, ref int m, ref int s)
        {
            s--;
            if (s < 0)
            {
                s = 59;
                m--;
                if (m < 0)
                {
                    m = 59;
                    h--;
                }
            }
        }

        public static int ConvertTimeToSecond(string time)
        {
            string[] temp = time.Split(':');
            int result = int.Parse(temp[0]) * 3600 + int.Parse(temp[1]) * 60 + int.Parse(temp[2]);
            return result;
        }

        public static string ConvertSecondToTime(int second)
        {
            int h, m, s;
            h = (int)Math.Floor(second / (Double)3600);
            m = (int)Math.Floor((second % 3600) / (Double)60);
            s = second % 3600 % 60;
            return $"{HandleTime(h)}:{HandleTime(m)}:{HandleTime(s)}";
        }

        public static string TimeElapse(string hour, string minute, string second, int currentLevel)
        {
            int totalSecondRemain = ConvertTimeToSecond($"{hour}:{minute}:{second}");

            int timeElapse = currentLevel * 60 - totalSecondRemain;

            return ConvertSecondToTime(timeElapse);
        }

        [Obsolete]
        public static void StopThreads(List<Thread> threads)
        {
            foreach (Thread thread in threads)
            {
                if (thread.IsAlive)
                {
                    thread.Suspend();
                }
            }
            threads.Clear();
        }

        public static void TimeCount(Label lbHour, Label lbMinute, Label lbSecond, bool isInPowerForm)
        {
            Thread Ts = new Thread(() =>
            {
                while (true)
                {
                    int h = Convert.ToInt32(lbHour.Text);
                    int m = Convert.ToInt32(lbMinute.Text);
                    int s = Convert.ToInt32(lbSecond.Text);
                    if (h == 0 && m == 0 && s == 0) return;
                    Timer(ref h, ref m, ref s);
                    timeList.Clear();
                    timeList.Add(lbHour.Text);
                    timeList.Add(lbMinute.Text);
                    timeList.Add(lbSecond.Text);

                    Thread.Sleep(1000);
                    
                    lbSecond.Text = HandleTime(s);
                    lbMinute.Text = HandleTime(m);
                    lbHour.Text = HandleTime(h);
                    if (h == 0 && m == 0 && s == 0)
                    {
                        TimeEndEvent?.Invoke(new object(),new EventArgs());
                        return;
                    }
                }

            });
            if (isInPowerForm)
                ThreadsOfPowerForm.Add(Ts);
            else
                ThreadCountDown.Add(Ts);
            Ts.IsBackground = true;
            Ts.Start();
        }
        
        #endregion

        public static List<string> timeList = new List<string>();
        public static bool isPowerStartClicked = false;
        public static string modePowerChosen = "Shut Down";
        public static DateTime timeSet = DateTime.Now;

        

        [Obsolete]
        public static void PowerModify(GroupBox powerGrpBox)
        {
            PowerFm = new PowerModifierForm(powerGrpBox);
            if (Application.OpenForms[PowerFm.Name] == null)
            {
                PowerFm.Show();
            }
            else
            {
                Application.OpenForms[PowerFm.Name].Focus();
            }
        }


        public static bool IsWin(List<PictureBox> ptrbList, int numberOfPiecesImg, List<Image> imgList)
        {
            for (int i = 0; i < numberOfPiecesImg; i++)
            {
                if (ImagesAreDifferent(ptrbList[i].Image, imgList[i]))
                {
                    return false;
                }
            }
            return true;
        }
        
        private static bool ImagesAreDifferent(Image img1, Image img2)
        {
            Bitmap bmp1 = new Bitmap(img1);
            Bitmap bmp2 = new Bitmap(img2);

            bool different = false;
            if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height)
            {
                for (int i = 0; i < bmp1.Width; i++)
                {
                    for (int j = 0; j < bmp1.Height; j++)
                    {
                        Color col1 = bmp1.GetPixel(i, j);
                        Color col2 = bmp2.GetPixel(i, j);
                        if (col1 != col2)
                        {
                            i = bmp1.Width + 1;
                            different = true;
                            break;
                        }
                    }
                }
            }
            return different;
        }
    }
}
