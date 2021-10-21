using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    public class OnClosePowerModifierFormEvent : EventArgs
    {
        private string hour;
        private string minute;
        private string second;
        private string mode;
        private bool isDisplay;


        public OnClosePowerModifierFormEvent()
        {

        }
        public OnClosePowerModifierFormEvent(bool isDisplay)
        {
            IsDisplay = isDisplay;
        }
        public OnClosePowerModifierFormEvent(string hour, string minute, string second, string mode)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Mode = mode;
        }

        public string Hour { get => hour; set => hour = value; }
        public string Minute { get => minute; set => minute = value; }
        public string Second { get => second; set => second = value; }
        public string Mode { get => mode; set => mode = value; }
        public bool IsDisplay { get => isDisplay; set => isDisplay = value; }
    }
}
