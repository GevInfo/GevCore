using GevCore.Extensions;
using GevCore.Timers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server.Utils
{
    public class MyConsole
    {
        public static int ErrorCount = 0;
        public static bool ShowInfos, ShowNotices, ShowWarnings;
        private static object ConsoleLock = new object();

        public static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region Writers
        public static void Write(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            bool High = false;

            foreach (char c in msg)
            {
                if (High && c == '@')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    High = false;
                }
                else if (!High && c == '@')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    High = true;
                }
                if (c != '@')
                {
                    Console.Write(c);
                }
            }

            Console.WriteLine();
        }

        public static void Write(string msg, ConsoleColor color)
        {
            Write(msg, color, true);
        }

        public static void Write(string msg, ConsoleColor color, bool line)
        {
            Console.ForegroundColor = color;

            if (line)
                Console.WriteLine(msg);
            else
                Console.Write(msg);
        }

        public static void SetName(int id, string value)
        {
            lock (ConsoleLock)
            {
                while (value.Length < 34)
                {
                    value += " ";
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.CursorTop = 8 + id * 2;
                Console.CursorLeft = 3;

                Console.Write(value);

                SetProperty(id, "0");
            }
        }

        public static void SetProperty(int id, string value)
        {
            lock (ConsoleLock)
            {
                lock (ConsoleLock)
                {
                    while (value.Length < 34)
                    {
                        value += " ";
                    }

                    Console.ForegroundColor = value.IsNumeric() ? value.ToFloat() >= 0 ? value.ToFloat() > 0 ? ConsoleColor.Green : ConsoleColor.Cyan : ConsoleColor.Red : ConsoleColor.Magenta;

                    Console.CursorTop = 8 + id * 2;
                    Console.CursorLeft = 23;

                    if (id == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(value);


                }
            }
        }

        public static void DrawLine(char character, ConsoleColor color)
        {
            string Bar = "  ";

            for (int i = 0; i < Console.BufferWidth - 5; i++)
            {
                Bar += character;
            }

            Write(Bar, color);
        }
        #endregion

        #region LoadingTicks
        private static SimpleTimerEntry TimerLoad;
        private static int StartX, StartY;
        private static int ActualSymbol;

        public static void StartLoading(string msg)
        {
            lock (ConsoleLock)
            {
                Write("[Info]", ConsoleColor.White, false);
                Write(": " + msg + " [-]", ConsoleColor.Gray, false);
                StartX = Console.CursorLeft - 2;
                StartY = Console.CursorTop;
                ActualSymbol = 0;
                TimerLoad = BaseServer.Pool.CallPeriodically(50, DoLoad);
            }
        }

        private static void DoLoad()
        {
            lock (ConsoleLock)
            {
                int lastX, lastY;
                lastX = Console.CursorLeft;
                lastY = Console.CursorTop;

                Console.SetCursorPosition(StartX, StartY);

                switch (ActualSymbol)
                {
                    case 0:
                        Console.Write("|");
                        break;
                    case 1:
                        Console.Write("/");
                        break;
                    case 2:
                        Console.Write("-");
                        break;
                    case 3:
                        Console.Write(@"\");
                        break;
                }

                Console.SetCursorPosition(lastX, lastY);

                ActualSymbol = ActualSymbol + 1 % 4;
            }
        }

        public static void StopLoading()
        {
            lock (ConsoleLock)
            {
                int lastX, lastY;
                lastX = Console.CursorLeft;
                lastY = Console.CursorTop;

                BaseServer.Pool.CancelSimpleTimer(TimerLoad);
                Console.SetCursorPosition(StartX - 1, StartY);
                Console.Write("Ok!");

                Console.SetCursorPosition(lastX, lastY);
            }
        }
        #endregion

        #region Messages and logs
        public static StreamWriter ErrWriter;

        public static void Status(string msg)
        {
            lock (ConsoleLock)
            {
                Write("[Status]", ConsoleColor.Green, false);
                Write(": " + msg);
            }
        }

        public static void Err(string value, bool fatal = false)
        {
            ErrorCount++;
            if (fatal)
            {
                Console.Clear();
                Write("       [FATAL ERROR]", ConsoleColor.Red);
                Write(value);
                Console.ReadKey();
                Environment.Exit(0);
                return;
            }
            else
            {
                if (ErrWriter != null)
                    StartLogs();

                ErrWriter.WriteLine("Exception caught at " + DateTime.Now.TimeOfDay.ToString() + " : ");
                ErrWriter.WriteLine();
                ErrWriter.WriteLine(value);
                ErrWriter.WriteLine();
                ErrWriter.WriteLine(" ----------- ");
                ErrWriter.WriteLine();
            }
        }

        public static void StartLogs()
        {
            if (!Directory.Exists("log/errors/"))
                Directory.CreateDirectory("logs/errors/");

            ErrWriter = new StreamWriter(new FileStream("log/errors/" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".txt", FileMode.Create));
            ErrWriter.AutoFlush = true;
        }
        #endregion

    }
}
