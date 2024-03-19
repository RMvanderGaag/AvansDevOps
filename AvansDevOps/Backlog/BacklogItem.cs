namespace AvansDevOps;

public class BacklogItem : BacklogComponent
{
    private List<BacklogComponent> _tasks = new List<BacklogComponent>();
    private string _name;
    public override bool IsComplete { get; set; }

    public BacklogItem(string name)
    {
        _name = name;
        IsComplete = false;
    }
    
    public void Add(BacklogComponent component)
    {
        _tasks.Add(component);
    }

    private bool CanComplete()
    {
         return _tasks.All(t => t.IsComplete); 
    }
    
    public override void Complete()
    {
        if (CanComplete())
        {
            IsComplete = true;
            Console.WriteLine($"Backlog item {_name} is now completed.");
        }
        else
        {
            Console.WriteLine($"Backlog item {_name} cannot be completed because some backlog items are not done yet.");
        }
    }
}