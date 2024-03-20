namespace AvansDevOps;

public class ReleaseSprint : Sprint
{
    public ReleaseSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
    {
    }
    
    // Notify scrum master and product owner via mail or Slack.
    public void Cancel()
    {
        this.CurrentState.CancelRelease();
    }

    public void StartRelease()
    {
        this.CurrentState.StartRelease();
    }
}