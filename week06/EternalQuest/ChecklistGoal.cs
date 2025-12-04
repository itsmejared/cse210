using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int totalPoints = GetPoints();

        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
        }

        return totalPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }

    public override string GetStringRepresentation()
    {
        // ChecklistGoal:Name|Description|Points|AmountCompleted|Target|Bonus
        return $"ChecklistGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
