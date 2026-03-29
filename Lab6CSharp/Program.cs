using System;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nChoose a task (1-4) or 0 to exit:");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": Task1.Execute(); break;
                    case "2": Task2.Execute(); break;
                    case "3": Task3.Execute(); break;
                    case "4": Task4.Execute(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}