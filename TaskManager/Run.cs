namespace TaskManager
{
    internal class Run
    {
        public void Start()
        {
            do
            {
                Console.WriteLine("Task Manager\n1. List all running tasks\n2. Kill any of the listed tasks\n3. Start a new process that exists in your system");

                int userInput;

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            Task.ListAllRunningProcesses();
                            break;
                        case 2:
                            Console.WriteLine("Enter name of process to end");
                            string name = Console.ReadLine();
                            Task.KillAnyOfTheListedTask(name);
                            break;
                        case 3:
                            Console.WriteLine("Enter name of process to end");
                            string name2 = Console.ReadLine();
                            Task.StartANewProcess(name2);
                            break;
                        case 4:
                            Console.WriteLine();
                            break;
                        case 5:
                            Console.WriteLine();
                            break;
                        case 6:
                            Console.WriteLine();
                            break;
                        case 7:
                            Console.WriteLine();
                            break;
                        case 0:
                            Console.WriteLine();
                            return;
                        default:
                            Console.WriteLine();
                            break;


                    }
                }
                catch { }
            } while (true);
        }
    }
}
