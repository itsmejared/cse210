using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("\nI'm thinking of a number between 1 and 100...");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessText = Console.ReadLine();
                guess = int.Parse(guessText);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }

            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("\nIt's ok! See you next time!");
    }
}