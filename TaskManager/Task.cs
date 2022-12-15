using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskManager
{
    internal class Task
    {
        private static Process _process = null;
      
        public static void ListAllRunningProcesses()
        {
            var runningprocess = from proc in Process.GetProcesses(".")
                                 orderby proc.Id
                                 select proc;

            foreach (var p in runningprocess)
            {
                Console.WriteLine($" PID: {p.Id}\tName: {p.ProcessName}");
            }
        }
        public static void KillAnyOfTheListedTask(string name)
        {
            try
            {
                foreach (var p in Process.GetProcessesByName(name))
                {
                    p.Kill(true);
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void StartANewProcess(string name)
        {
            try
            {
                _process = Process.Start(@$"{name}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void StartAndKillACustomProcess()
        {  
            try
            {
                _process = Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
               "www.twitter.com");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Press enter to kill {0}",
            _process.ProcessName);
            Console.ReadLine();
            
            try
            {
                foreach (var p in Process.GetProcessesByName("MsEdge"))
                {
                    p.Kill(true);
                }
                
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal static void IsThreadAliveAndIsBackground()
        {
            
                Console.WriteLine("1. Check if thread is Alive\n2. Check for Is Background properties\n0. Return");

                try
                {
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                        Task.IsAlive();
                            break;
                        case 2:
                            Task.IsBackground();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid option! Please choose from options 1 - 2");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            
        }

        private static void IsAlive()
        {
            bool isAlive = Thread.CurrentThread.IsAlive;
            Console.WriteLine(isAlive ? "Thread is alive" : "Thread is not alive");
        }
        private static void IsBackground()
        {
            bool isBackground = Thread.CurrentThread.IsBackground;
            Console.WriteLine(isBackground? "This is a background thread" : "This is not a background thread");
        }
    }
}
