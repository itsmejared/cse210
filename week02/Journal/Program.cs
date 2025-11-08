/*
Enhancements Report:
1. Mood tracking – allows users to record how they felt for each entry.
2. CSV file saving/loading – entries can be opened in Excel or Google Sheets safely.
3. JSON file saving/loading – modern data format for structured storage and easy sharing.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal as CSV");
            Console.WriteLine("4. Load the journal from CSV");
            Console.WriteLine("5. Save the journal as JSON");
            Console.WriteLine("6. Load the journal from JSON");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option (1-7): ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling today? ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._mood = mood;

                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save (example: journal.csv): ");
                string filename = Console.ReadLine();
                myJournal.SaveToCsv(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load (example: journal.csv): ");
                string filename = Console.ReadLine();
                myJournal.LoadFromCsv(filename);
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to save (example: journal.json): ");
                string filename = Console.ReadLine();
                myJournal.SaveToJson(filename);
            }
            else if (choice == "6")
            {
                Console.Write("Enter filename to load (example: journal.json): ");
                string filename = Console.ReadLine();
                myJournal.LoadFromJson(filename);
            }
            else if (choice == "7")
            {
                Console.WriteLine("See you next time!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
