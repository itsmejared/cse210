using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "Who made my day better and how?",
        "What challenge did I face today, and how did I handle it?",
        "What am I grateful for right now?",
        "What is something I want to remember about today?",
        "When did I feel peace today?",
        "What did I do to help someone today?",
        "What made me laugh today?",
        "What’s one small success I had today?",
        "What did I notice in nature today?",
        "What’s something I want to improve tomorrow?",
        "What advice would I give myself based on today?",
        "What was a moment I felt close to God today?",
        "How did I show kindness or love today?",
        "What is something that inspired me today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
