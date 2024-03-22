namespace AvansDevOps;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(string name, DateTime startDate, DateTime endDate, User user) : base(name, startDate, endDate, user)
    {
    }
    
    // Notify scrum master and product owner via mail or Slack.
    public void Cancel()
    {
        this.CurrentState.CancelRelease();
    }
    
}