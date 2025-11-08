using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        Console.WriteLine("\nJournal Entries:\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToCsv(string file)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine("Date,Prompt,Mood,Entry");
                foreach (Entry entry in _entries)
                {
                    string date = EscapeCsv(entry._date);
                    string prompt = EscapeCsv(entry._promptText);
                    string mood = EscapeCsv(entry._mood);
                    string text = EscapeCsv(entry._entryText);

                    outputFile.WriteLine($"\"{date}\",\"{prompt}\",\"{mood}\",\"{text}\"");
                }
            }
            Console.WriteLine($"\nJournal saved successfully as CSV to '{file}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}\n");
        }
    }

    private string EscapeCsv(string text)
    {
        if (text.Contains("\""))
            text = text.Replace("\"", "\"\"");
        return text;
    }

    public void LoadFromCsv(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                _entries.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = SplitCsvLine(line);

                    if (parts.Length == 4)
                    {
                        Entry entry = new Entry();
                        entry._date = parts[0];
                        entry._promptText = parts[1];
                        entry._mood = parts[2];
                        entry._entryText = parts[3];
                        _entries.Add(entry);
                    }
                }

                Console.WriteLine($"\nJournal loaded successfully from '{file}'.");
                Console.WriteLine($"Entries loaded: {_entries.Count}\n");
            }
            else
            {
                Console.WriteLine($"\nFile '{file}' not found.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}\n");
        }
    }

    private string[] SplitCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '\"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                parts.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }

        parts.Add(current);
        return parts.ToArray();
    }

    public void SaveToJson(string file)
    {
        try
        {
            string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(file, json);
            Console.WriteLine($"\nJournal saved as JSON to '{file}'.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving JSON: {ex.Message}\n");
        }
    }

    public void LoadFromJson(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                _entries = JsonSerializer.Deserialize<List<Entry>>(json);
                Console.WriteLine($"\nJournal loaded from JSON file '{file}'.");
                Console.WriteLine($"Entries loaded: {_entries.Count}\n");
            }
            else
            {
                Console.WriteLine($"\nFile '{file}' not found.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading JSON: {ex.Message}\n");
        }
    }
}
