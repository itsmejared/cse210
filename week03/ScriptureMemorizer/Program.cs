/* ENHANCEMENTS: This program includes a external scripture-loading system, 
selecting menu, UTF-8 compliant text parsing to safely handle accented characters, 
random hiding of 1–3 words, punctuation preservation, console color UI, 
and only hiding visible words.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Scripture Memorizer version Jared";

        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No scriptures loaded. Program will exit.");
            Console.ResetColor();
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
            return;
        }

        Scripture selectedScripture = SelectScripture(scriptures);
        string input = "";
        Random random = new Random();

        while (input.ToLower() != "quit" && !selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.ResetColor();

            Console.WriteLine($"\nProgress: {selectedScripture.GetHiddenPercentage():0}% hidden");

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit...");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                int wordsToHide = random.Next(1, 4);
                selectedScripture.HideRandomWords(wordsToHide);
            }
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Well done!");
    }

    static string? GetFile(string fileName)
    {
        string exePath = Path.Combine(AppContext.BaseDirectory, fileName);
        if (File.Exists(exePath))
            return exePath;

        string projectPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, @"..\..\..\", fileName)
        );

        if (File.Exists(projectPath))
            return projectPath;

        return null;
    }

    static List<Scripture> LoadScripturesFromFile(string fileName)
    {
        List<Scripture> list = new List<Scripture>();

        string? filePath = GetFile(fileName);

        if (filePath == null)
            return list;

        using (var reader = new StreamReader(filePath, Encoding.UTF8))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split('|');
                if (parts.Length < 5)
                    continue;

                string book = parts[0];
                string text = parts[4];

                // Numeric checks
                if (!int.TryParse(parts[1], out int chapter)) continue;
                if (!int.TryParse(parts[2], out int startVerse)) continue;
                if (!int.TryParse(parts[3], out int endVerse)) continue;

                Reference reference = endVerse == -1
                    ? new Reference(book, chapter, startVerse)
                    : new Reference(book, chapter, startVerse, endVerse);

                list.Add(new Scripture(reference, text));
            }
        }

        return list;
    }
    
    static Scripture SelectScripture(List<Scripture> scriptures)
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Random scripture");
        Console.WriteLine("2. Select scripture by number");
        Console.Write("\nYour choice: ");
        string choice = Console.ReadLine();

        if (choice == "2")
        {
            Console.Clear();
            Console.WriteLine("Available scriptures:\n");

            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText().Split('\n')[0]}");
            }

            Console.Write("\nEnter number: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            return scriptures[index];
        }

        Random rand = new Random();
        return scriptures[rand.Next(scriptures.Count)];
    }
}
