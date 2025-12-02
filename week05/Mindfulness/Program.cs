/*
 Enhancements:
 - Added a session log (log.txt) to record completed activities.
 - Improved prompt/question selection so nothing repeats until all options are used.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("====================");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit\n");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
                continue;

            Activity activity = choice switch
            {
                1 => new BreathingActivity(),
                2 => new ReflectingActivity(),
                3 => new ListingActivity(),
                _ => null
            };

            if (activity != null)
            {
                Console.Clear();
                activity.Run();
            }
        }

        Console.Clear();
        Console.WriteLine("Thanks for using the Mindfulness Program!");
    }
}
