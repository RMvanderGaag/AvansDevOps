namespace AvansDevOps;

public class SprintCancelled : SprintStateBase
{
    
    public SprintCancelled(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint has been cancelled.");
    }
}