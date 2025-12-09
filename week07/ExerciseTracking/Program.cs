using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("03 Nov 2022", 45, 15.0));
        activities.Add(new Swimming("03 Nov 2022", 25, 40));

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
