namespace TaskManager
{
    internal class CustomThread
    {
        public static void SecondaryThread()
        {
            Thread backgroundThread = new Thread(new ThreadStart (CustomThread.GuessGame));

            backgroundThread.Name = "Secondary";
            backgroundThread.Start();
        }

        public static void Run()
        {

            try
            {
                Console.WriteLine("Do you want  1 or 2 Threads or Press 0 to return");
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        Thread primaryThread = Thread.CurrentThread;
                        primaryThread.Name = "Primary";
                        CustomThread.GuessGame();
                        break;

                    case "2":
                        CustomThread.SecondaryThread();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                

            }
            catch
            {
                Console.WriteLine("Hmm");
            }


        }

        public static void GuessGame()
        {

            Console.WriteLine("{0} is executing Guess game.\n Please guess a number between 1 - 10", Thread.CurrentThread.Name);

            Random number = new Random();
            int secretNumber = 0;
            int myGuess = 0;
            int count = 0;
            List<int> guessList = new();

            secretNumber = number.Next(1, 11);

            while (count < 3)
            {
                try
                {
                    Console.WriteLine("Guess A Number");

                    myGuess = Convert.ToInt32(Console.ReadLine());

                    if (!guessList.Contains(myGuess))
                    {
                        guessList.Add(myGuess);

                    }


                    if (myGuess < 0 || myGuess > 10)
                    {
                        Console.WriteLine("Enter a number between 1 - 10 ");
                    }

                    else if (myGuess > secretNumber)
                    {
                        Console.WriteLine("Too high!!");
                    }

                    else if (myGuess < secretNumber)
                    {
                        Console.WriteLine("Too low!!");
                    }

                    else
                    {
                        Console.WriteLine($"Yeaaaaaaaahh!!! Secret Number = {secretNumber}");
                        Console.WriteLine("You had 3 tries");
                        Console.WriteLine($"You got it on guess number {guessList.Count}");
                        break;
                    }

                    count++;

                }
                catch { Console.WriteLine("Hmm"); }
            }
        }
    }
}
