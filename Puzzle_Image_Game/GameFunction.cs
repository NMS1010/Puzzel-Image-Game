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
        public static event EventHandler<OnCloseChooseLevelFormEvent> closeChooseLevelEvent;
        public static event EventHandler<OnCloseChooseImageFormEvent> closeChooseImageEvent;
        public static event EventHandler<OnClosePowerModifierFormEvent> closePowerFormWhenPressStartEvent;
        public static event EventHandler<OnClosePowerModifierFormEvent> closePowerFormWhenPressCancelEvent;
        public static event EventHandler<OnClosePowerModifierFormEvent> closePowerFormWhenClosingEvent;
        public static event EventHandler<EventArgs> TimeEndEvent;

        private static ChooseLevelForm chooseLvForm;
        private static ChooseImageForm chooseImgForm;
        private static PowerModifierForm powerFm;
        private static List<Thread> threadsOfPowerForm;
        private static List<Thread> threadCountDown;

        static GameFunction()
        {
            ThreadsOfPowerForm = new List<Thread>();
            ThreadCountDown = new List<Thread>();
        }
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
        public static List<Image> Mix(List<Image> imgList, int count)
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
            chooseLvForm = new ChooseLevelForm(numberOfCol);
            if (Application.OpenForms[chooseLvForm.Name] == null)
            {
                chooseLvForm.Show();
            }
            else
            {
                Application.OpenForms[chooseLvForm.Name].Focus();
            }
            chooseLvForm.CloseLevelFormEvent += ChooseLvForm_CloseLevelFormEvent;
        }

        private static void ChooseLvForm_CloseLevelFormEvent(object sender, OnCloseChooseLevelFormEvent e)
        {
            closeChooseLevelEvent?.Invoke(sender, new OnCloseChooseLevelFormEvent(e.Level));
        }

        public static void PlayMusic()
        {
            
        }
        
        public static void ChooseImage()
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

        private static void ChooseImgForm_closeChooseImgForm(object sender, OnCloseChooseImageFormEvent e)
        {
            closeChooseImageEvent?.Invoke(sender, new OnCloseChooseImageFormEvent(e.Path));
            chooseImgForm.closeChooseImgForm -= ChooseImgForm_closeChooseImgForm;
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
                        TimeEndEvent(new object(),new EventArgs());
                        return;
                    }
                }

            });
            if (isInPowerForm)
                ThreadsOfPowerForm.Add(Ts);
            else
                ThreadCountDown.Add(Ts);
            Ts.Start();
        }
        
        public static List<string> timeList = new List<string>();
        public static bool isPowerStartClicked = false;
        public static string modePowerChosen = "Shut Down";
        public static DateTime timeSet = DateTime.Now;

        public static List<Thread> ThreadsOfPowerForm { get => threadsOfPowerForm; set => threadsOfPowerForm = value; }
        public static List<Thread> ThreadCountDown { get => threadCountDown; set => threadCountDown = value; }

        public static void PowerModify(GroupBox powerGrpBox)
        {
            powerFm = new PowerModifierForm(powerGrpBox);
            if (Application.OpenForms[powerFm.Name] == null)
            {
                powerFm.Show();
            }
            else
            {
                Application.OpenForms[powerFm.Name].Focus();
            }
            powerFm.HandleTimeWhenPressStart += PowerFm_HandleTimeWhenPressStart;
            powerFm.HandleTimeWhenPressCancel += PowerFm_HandleTimeWhenPressCancel;
            powerFm.HandleTimeWhenClosing += PowerFm_HandleTimeWhenClosing;

        }

        private static void PowerFm_HandleTimeWhenClosing(object sender, OnClosePowerModifierFormEvent e)
        {
            closePowerFormWhenClosingEvent?.Invoke(sender, new OnClosePowerModifierFormEvent(e.IsDisplay));
        }

        private static void PowerFm_HandleTimeWhenPressCancel(object sender, OnClosePowerModifierFormEvent e)
        {
            closePowerFormWhenPressCancelEvent?.Invoke(sender, new OnClosePowerModifierFormEvent());
        }

        private static void PowerFm_HandleTimeWhenPressStart(object sender, OnClosePowerModifierFormEvent e)
        {
            closePowerFormWhenPressStartEvent?.Invoke(sender, new OnClosePowerModifierFormEvent(e.Hour, e.Minute, e.Second, e.Mode));
        }

        public static void ChooseMode()
        {

        }
        public static bool IsWin(List<PictureBox> ptrbList, int numberOfPiecesImg, List<Image> imgList)
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
