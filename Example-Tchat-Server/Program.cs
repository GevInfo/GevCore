using Example_Tchat_Server.Network;
using Example_Tchat_Server.Test;
using Example_Tchat_Server.Utils;
using GevCore.Datas.S2d;
using GevCore.Network;
using GevCore.Thread;
using ShadowEmu.ORM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConsole.Write("Lancement du serveur !");
            ProtocolTypeManager.Initialize();
            MessageReceiver.Initialize();
            BaseServer.Pool = new SelfRunningTaskPool(50, "timer"); ;
            AuthServer.Instance.Start();
            BaseServer.StartTime = Environment.TickCount;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            System.Threading.Thread.Sleep(2500); // Histoire de voir ce que l'emu ecris :)

            Console.Clear();
            ServerStats.SetupStats();

            while (true)
            {

            }
        }
    }
}
