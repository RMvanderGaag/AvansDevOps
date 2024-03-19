namespace AvansDevOps;

public class Subtask : BacklogComponent
{
    private string _name;
    public override bool IsComplete { get; set; }
    public Subtask(string name)
    {
        _name = name;
        IsComplete = false;
    }
    
    
    public override void Complete()
    {
        IsComplete = true;
        Console.WriteLine($"Subtask {_name} is now completed.");
    }
}