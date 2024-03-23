namespace AvansDevOps;

public class SprintFinished : SprintStateBase
{
    public SprintFinished(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint has finished.");
    }
    
    public override void CancelSprint()
    {
        _sprint.Notify("Sprint has been cancelled.", ["Scrum Master"]);
    }

    public override void StartRelease(bool failRelease)
    {
        _sprint.ChangeState(new ReleaseStarted(_sprint, failRelease));
    }

    public override void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public override void StartReview()
    {
        _sprint.ChangeState(new SprintReviewing(_sprint));
    }
}