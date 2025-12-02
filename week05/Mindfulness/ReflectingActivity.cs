using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;

    public ReflectingActivity()
        : base("Reflection Activity",
        "This activity will help you think deeply about moments of resilience, strength, and growth.")
    {
        // 20 PROMPTS
        _prompts = new()
        {
            "Think of a time when you helped someone without expecting anything in return.",
            "Think of a moment when you overcame fear and acted with courage.",
            "Think of a time when you forgave someone who hurt you.",
            "Think of a moment when you felt guided or inspired unexpectedly.",
            "Think of a time when you accomplished something difficult through persistence.",
            "Think of a moment when you comforted someone who was struggling.",
            "Think of a time when you learned something important from a mistake.",
            "Think of a moment when you felt true peace or clarity.",
            "Think of a time when you chose to be honest even when it was hard.",
            "Think of a moment when you stood up for someone who needed support.",
            "Think of a time when you achieved something you once thought impossible.",
            "Think of a moment when you served someone quietly, without anyone noticing.",
            "Think of a time when you encouraged or strengthened someone.",
            "Think of a moment when you handled a stressful situation better than you expected.",
            "Think of a time when you acted kindly toward someone who wasn’t kind to you.",
            "Think of a moment when you made a thoughtful sacrifice for someone else.",
            "Think of a time when you learned something valuable about yourself.",
            "Think of a moment when you were brave and tried something new.",
            "Think of a time when you helped resolve a conflict or misunderstanding.",
            "Think of a moment when you felt grateful for the small things in life."
        };

        // 20 QUESTIONS
        _questions = new()
        {
            "Why was this experience meaningful to you?",
            "What emotions did you feel before, during, and after the experience?",
            "What strengths did you use in that moment?",
            "What did you learn about yourself from this experience?",
            "How did you decide what to do in that situation?",
            "What challenges did you face and how did you handle them?",
            "What surprised you about how you acted or responded?",
            "How did this experience change you, even in a small way?",
            "How can you apply the lessons from this experience in the future?",
            "Who else was affected by your actions and how?",
            "What was the most difficult part of the experience?",
            "What part of your character was strengthened through this moment?",
            "How did you feel after everything was over?",
            "Is there anything you would do differently if it happened again?",
            "What does this experience reveal about your personal values?",
            "What motivated you to take action in that moment?",
            "What can you be proud of in this experience?",
            "What positive outcomes came from this situation?",
            "How did your faith, beliefs, or principles influence your actions?",
            "How can remembering this experience help you in future challenges?"
        };

        // Initialize shuffled queues
        _promptQueue = ShuffleIntoQueue(_prompts);
        _questionQueue = ShuffleIntoQueue(_questions);
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

    private string GetNextQuestion()
    {
        if (_questionQueue.Count == 0)
            _questionQueue = ShuffleIntoQueue(_questions);

        return _questionQueue.Dequeue();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine("\nPress ENTER when you're ready to continue...");
        Console.ReadLine();

        Console.WriteLine("\nReflect on the following questions:");
        Console.Write("Starting in: ");
        ShowCountDown(5);
        Console.WriteLine();

        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            string q = GetNextQuestion();
            Console.WriteLine($"> {q}");
            ShowProgressBar(5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
