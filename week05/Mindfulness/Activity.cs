using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void LogActivityCompletion()
    {
        string line = $"{DateTime.Now} - Completed {_name} for {_duration} seconds";
        string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string logPath = Path.Combine(projectPath, "log.txt");

        File.AppendAllText(logPath, line + Environment.NewLine);
    }


    // ----------------------
    // Start / End Messages
    // ----------------------
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"--- Welcome to the {_name} ---\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like your session to last? ");

        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowProgressBar(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job!");
        ShowProgressBar(3);

        Console.WriteLine($"\nYou completed {_duration} seconds of the {_name}.");
        ShowProgressBar(3);

        LogActivityCompletion();
    }

    public int GetDuration()
    {
        return _duration;
    }

    // ----------------------
    // Animations
    // ----------------------
    public void ShowProgressBar(int seconds)
    {
        string[] frames = {
        "[=     ]",
        "[==    ]",
        "[===   ]",
        "[====  ]",
        "[===== ]",
        "[======]",
        "[===== ]",
        "[====  ]",
        "[===   ]",
        "[==    ]"
    };

        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            string frame = frames[i];

            Console.Write(frame);
            Thread.Sleep(200);
            Console.Write(new string('\b', frame.Length) +
                          new string(' ', frame.Length) +
                          new string('\b', frame.Length));

            i = (i + 1) % frames.Length;
        }
    }


    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public virtual void Run() { }
}
