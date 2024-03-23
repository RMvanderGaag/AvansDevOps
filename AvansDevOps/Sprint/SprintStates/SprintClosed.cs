namespace AvansDevOps;

public class SprintClosed : SprintStateBase
{
    
    public SprintClosed(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint has been closed.");
    }
}