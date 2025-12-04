using System;

public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Solo se completa una vez
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public void MarkComplete()
    {
        _isComplete = true;
    }

    public override string GetStringRepresentation()
    {
        // SimpleGoal:Name|Description|Points|IsComplete
        return $"SimpleGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }
}
