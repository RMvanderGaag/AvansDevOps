namespace AvansDevOps;

public class ReleaseDone : SprintStateBase
{
    
    public ReleaseDone(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Release has been completed.");
    }
}