namespace AvansDevOps;

public class Sprint
{
    public string Name { get; }
    private bool _isClosed = false;
    private readonly ISprintState _state;
    
    public void CloseSprint()
    {
        _isClosed = true;
        Console.WriteLine($"Sprint {Name} is now closed.");
    }
}