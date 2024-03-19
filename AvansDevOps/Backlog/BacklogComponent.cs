namespace AvansDevOps;

public abstract class BacklogComponent
{
    public abstract bool IsComplete { get; set; }
    public abstract void Complete();
    public User? AssignedTo { get; private set; }

    public void AssignTo(User user)
    {
        AssignedTo = user;
        Console.WriteLine($"{GetType().Name} is now assigned to {user.Name}.");
    }
    
}