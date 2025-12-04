using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
        }
    }

    private void UpdateLevel()
    {
        _level = (_score / 500) + 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. | Level {_level}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Lose points)");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;

            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;

            case "4":
                newGoal = new NegativeGoal(name, description, points);
                break;

            default:
                Console.WriteLine("Invalid type. Goal not created.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out int goalIndex))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        goalIndex -= 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = _goals[goalIndex];
        int points = goal.RecordEvent();
        _score += points;

        UpdateLevel();

        if (points >= 0)
            Console.WriteLine($"You earned {points} pts!");
        else
            Console.WriteLine($"You lost {-points} pts!");

        Console.WriteLine($"Total Score: {_score} | Level {_level}");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fullPath = Path.Combine(projectRoot, filename);

        using (StreamWriter outputFile = new StreamWriter(fullPath))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved to: {fullPath}");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string fullPath = Path.Combine(projectRoot, filename);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File not found at: {fullPath}");
            return;
        }

        string[] lines = File.ReadAllLines(fullPath);
        _goals.Clear();

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] info = parts[1].Split("|");

            switch (type)
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(info[0], info[1], int.Parse(info[2]));
                    if (bool.Parse(info[3])) sg.MarkComplete();
                    _goals.Add(sg);
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(info[0], info[1], int.Parse(info[2])));
                    break;

                case "ChecklistGoal":
                    var cg = new ChecklistGoal(info[0], info[1], int.Parse(info[2]),
                                              int.Parse(info[4]), int.Parse(info[5]));
                    cg.SetAmountCompleted(int.Parse(info[3]));
                    _goals.Add(cg);
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(info[0], info[1], int.Parse(info[2])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}
