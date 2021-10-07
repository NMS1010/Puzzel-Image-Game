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
    public class FunctionInGame
    {
        public event EventHandler<CloseChooseLevelFormEvent> closeChooseLevelEvent;
        public event EventHandler<CloseChooseImageFormEvent> closeChooseImageEvent;

        private ChooseLevelForm chooseLvForm;
        private ChooseImageForm chooseImgForm;
        private static Thread ts;

        public static Thread Ts { get => ts; set => ts = value; }

        public List<Image> Mix(List<Image> imgList, int count)
        {
            List<Image> imgs = new List<Image>();
            List<int> numbersRandom = new List<int>();
            Random rand = new Random();
            int number;
            for(int i = 0; i < count; i++)
            {
                do
                {
                   number = rand.Next(0,count);
                } while (numbersRandom.Contains(number));
                numbersRandom.Add(number);
                imgs.Add(imgList[number]);
            }
            return imgs;
        }

        public void ChooseLevel(int numberOfCol)
        {
            chooseLvForm = new ChooseLevelForm(numberOfCol);
            if (Application.OpenForms[chooseLvForm.Name] == null)
            {
                chooseLvForm.Show();
            }
            else
            {
                Application.OpenForms[chooseLvForm.Name].Focus();
            }
            chooseLvForm.CloseFormEvent += ChooseLvForm_CloseFormEvent;
        }

        private void ChooseLvForm_CloseFormEvent(object sender, CloseChooseLevelFormEvent e)
        {
            closeChooseLevelEvent?.Invoke(this, new CloseChooseLevelFormEvent(e.Level));
        }

        public void PlayMusic()
        {
            
        }

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
        public static void TimeCount(Label lbHour, Label lbMinute, Label lbSecond)
        {
            Ts = new Thread(() =>
            {
                while (true)
                {
                    int h = Convert.ToInt32(lbHour.Text);
                    int m = Convert.ToInt32(lbMinute.Text);
                    int s = Convert.ToInt32(lbSecond.Text);
                    if (h == 0 && m == 0 && s == 0) return;
                    Timer(ref h, ref m, ref s);
                    Thread.Sleep(1000);
                    lbSecond.Text = HandleTime(s);
                    lbMinute.Text = HandleTime(m);
                    lbHour.Text = HandleTime(h);
                    timeList.Clear();
                    timeList.Add(lbHour.Text);
                    timeList.Add(lbMinute.Text);
                    timeList.Add(lbSecond.Text);
                }

            });
            Ts.IsBackground = true;
            Ts.Start();
        }
        public void ChooseImage()
        {
            chooseImgForm = new ChooseImageForm();
            
            if(Application.OpenForms[chooseImgForm.Name] == null)
            {
                chooseImgForm.Show();
            }
            else
            {
                Application.OpenForms[chooseImgForm.Name].Focus();
            }
            chooseImgForm.closeChooseImgForm += ChooseImgForm_closeChooseImgForm;
        }

        private void ChooseImgForm_closeChooseImgForm(object sender, CloseChooseImageFormEvent e)
        {
            closeChooseImageEvent?.Invoke(sender, new CloseChooseImageFormEvent(e.ImgPath));
        }

        public static List<string> timeList = new List<string>();
        public static bool isPowerStartClicked = false;
        public static string modePowerChosen;
        public void PowerModify()
        {
            PowerModifier powerFm = new PowerModifier();
            if (Application.OpenForms[powerFm.Name] == null)
            {
                powerFm.Show();
            }
            else
            {
                Application.OpenForms[powerFm.Name].Focus();
            }
        }
        public void ChooseMode()
        {

        }
        public bool IsWin(List<PictureBox> ptrbList, int numberOfPiecesImg, List<Image> imgList)
        {
            
            for (int i = 0; i < numberOfPiecesImg; i++)
            {
                if (ptrbList[i].Image != imgList[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
