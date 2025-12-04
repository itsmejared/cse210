using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Nunca se completa, solo da puntos cada vez
        return GetPoints();
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetStringRepresentation()
    {
        // EternalGoal:Name|Description|Points
        return $"EternalGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }
}
