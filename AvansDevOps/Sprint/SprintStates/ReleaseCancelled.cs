namespace AvansDevOps;

public class ReleaseCancelled : SprintStateBase
{
    public ReleaseCancelled(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Release has been cancelled.");
    }
    
}