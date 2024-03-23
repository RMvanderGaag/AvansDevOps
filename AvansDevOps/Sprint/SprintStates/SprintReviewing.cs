namespace AvansDevOps;

public class SprintReviewing : SprintStateBase
{
    public SprintReviewing(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint review has started.");
    }
    
    public override void CloseSprint(string review)
    {
        if (string.IsNullOrEmpty(review)) return;
        
        _sprint.ChangeState(new SprintClosed(_sprint));
    }
}