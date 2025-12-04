/* 
To exceed the core requirements, I added a leveling system where the user gains a new level every 500 points,
 and I created a new NegativeGoal type that subtracts points instead of adding them. These features enhance 
 the gamification experience by introducing progression and the ability to track negative habits, going beyond 
 the basic goal types required.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
