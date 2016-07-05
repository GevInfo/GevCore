using Example_Tchat_Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server.Utils
{
    public class ServerStats
    {
        public enum LeftStats
        {
            UpTime,
            ClientConnected,
            NumberErrors

        }

        private static long[] LeftValues = new long[7];
        private static GevCore.Timers.SimpleTimerEntry Timer;

        private static void UpdateTask()
        {
            try
            {
                SetStat(LeftStats.UpTime, BaseServer.GetUpTime());
                SetStat(LeftStats.ClientConnected, AuthServer.Instance.GetClientsCount().ToString());
                SetStat(LeftStats.NumberErrors, "0");
            }
            catch (Exception ex)
            {
                MyConsole.Err(ex.Message, true);
                throw;
            }
        }

        public static void SetupStats()
        {
            Timer = BaseServer.Pool.CallPeriodically(500, UpdateTask);

            MyConsole.SetName((int)LeftStats.UpTime, "UpTime");
            MyConsole.SetName((int)LeftStats.ClientConnected, "Clients Online");
            MyConsole.SetName((int)LeftStats.NumberErrors, "Errors");
        }

        public static void SetStat(LeftStats stat, string value)
        {
            MyConsole.SetProperty((int)stat, value);
        }
    }
}
