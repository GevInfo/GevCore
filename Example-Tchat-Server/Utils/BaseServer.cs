using GevCore.Thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server.Utils
{
    public static class BaseServer
    {
        public static SelfRunningTaskPool Pool
        {
            get;
            set;
        }

        public static long StartTime = 0;
        public static string GetUpTime()
        {
            TimeSpan TempTime = TimeSpan.FromMilliseconds(Environment.TickCount - StartTime);
            return Math.Floor(TempTime.TotalHours) + "h " + TempTime.Minutes + "m " + TempTime.Seconds + "s";
        }
    }
}
