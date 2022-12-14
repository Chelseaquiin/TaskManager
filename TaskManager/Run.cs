namespace TaskManager
{
    internal class Run
    {
        public void Start()
        {
            do
            {
                Console.WriteLine("Task Manager\n1. List all running tasks\n2. Kill any of the listed tasks\n" +
                    "3. Start a new process that exists in your system\n4. Start and kill a custom process\n5. Create a custom thread\n" +
                    "6. Check if a thread is alive.\n0. Exit");

                int userInput;

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            Task.ListAllRunningProcesses();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Enter name of process to end");
                            string name = Console.ReadLine();
                            Task.KillAnyOfTheListedTask(name);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Enter name of process to start");
                            string name2 = Console.ReadLine();
                            Task.StartANewProcess(name2);
                            break;
                        case 4:
                            Console.Clear();
                            Task.StartAndKillACustomProcess();
                            break;
                        case 5:
                            Console.Clear();
                            CustomThread.Run();
                            break;
                        case 6:
                            Console.Clear();
                            Task.IsThreadAliveAndIsBackground();
                            break;
                        case 0:
                            Console.WriteLine("Thank you for using Task Manager");
                            return;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                catch 
                {
                    Console.WriteLine("We must find the problem");
                }
            } while (true);
        }
    }
}
