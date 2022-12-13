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
        public Process process;
        public List<Process> processList { get; set; } = new List<Process>();
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
            Process process = null;

            try
            {
                process = Process.Start(@$"{name}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
