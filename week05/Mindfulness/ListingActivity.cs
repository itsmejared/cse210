using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Queue<string> _promptQueue;

    public ListingActivity()
        : base("Listing Activity",
        "This activity will help you recognize positive things in your life by listing as many items as you can.")
    {
        // 20 PROMPTS
        _prompts = new()
        {
            "Who are people you appreciate?",
            "What are some of your personal strengths?",
            "Who have you helped recently?",
            "What moments brought you peace this month?",
            "Who are your role models?",
            "What blessings have you received lately?",
            "What things always make you smile?",
            "What are some things you love about your personality?",
            "Who has had a positive impact on your life?",
            "What talents or skills are you grateful for?",
            "What experiences have strengthened your faith?",
            "What things in your home make you feel safe or happy?",
            "What memories bring you joy?",
            "Who has shown kindness to you recently?",
            "What accomplishments are you proud of?",
            "What opportunities have blessed your life?",
            "What answers to prayer have you noticed lately?",
            "What good habits are you developing?",
            "Who in your life inspires you to be better?",
            "What simple things today made your day better?"
        };

        _promptQueue = ShuffleIntoQueue(_prompts);
    }

    private Queue<string> ShuffleIntoQueue(List<string> list)
    {
        Random r = new Random();
        List<string> copy = new List<string>(list);

        for (int i = 0; i < copy.Count; i++)
        {
            int j = r.Next(copy.Count);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }

        return new Queue<string>(copy);
    }

    private string GetNextPrompt()
    {
        if (_promptQueue.Count == 0)
            _promptQueue = ShuffleIntoQueue(_prompts);

        return _promptQueue.Dequeue();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many items as you can related to the following prompt:");
        Console.WriteLine($"--- {GetNextPrompt()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        List<string> items = new();

        Console.WriteLine("\nStart listing items:\n");

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        DisplayEndingMessage();
    }
}
