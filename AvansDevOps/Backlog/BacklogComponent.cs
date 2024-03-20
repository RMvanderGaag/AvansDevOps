namespace AvansDevOps;

public abstract class BacklogComponent
{
    protected string _name;
    protected BacklogComponent(string name)
    {
        this._name = name;
    }
    
    public abstract bool IsComplete { get; set; }
    public User? AssignedTo { get; private set; }

    public void AssignTo(User user)
    {
        AssignedTo = user;
        Console.WriteLine($"{GetType().Name} is now assigned to {user.Name}.");
    }
    
}