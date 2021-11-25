using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Image_Game
{
    static class Power
    {
        private static string processName;
        private static string typeName;
        private static ProcessStartInfo process;

        private static string GetPowerType(string type)
        {
            string name = "";
            switch(type){
                case "Shut Down": name= "-s"; break;
                case "Restart": name= "-r"; break;
            }
            return name;
        }

        public static void PowerManager(string type)
        {
            processName = "shutdown.exe";
            typeName = GetPowerType(type);
            process = new ProcessStartInfo(processName, typeName);
            Process.Start(process);
        }
    }
}
