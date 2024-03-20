namespace AvansDevOps;

public class Subtask : BacklogComponent
{
    public override bool IsComplete { get; set; }

    public Subtask(string name) : base(name)
    {
    }

    public void Complete()
    {
        IsComplete = true;
        Console.WriteLine($"Subtask {_name} is now completed.");
    }
}