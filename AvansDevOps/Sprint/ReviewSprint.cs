namespace AvansDevOps;

public class ReviewSprint : Sprint
{
    public string? Review { get; private set; }
    
    public ReviewSprint(string name, DateTime startDate, DateTime endDate, User user) : base(name, startDate, endDate, user) {}
    
}