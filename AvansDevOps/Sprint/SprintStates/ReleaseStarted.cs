namespace AvansDevOps;

public class ReleaseStarted : SprintStateBase
{
    
    public ReleaseStarted(Sprint sprint, bool failRelease) : base(sprint)
    {
        Console.WriteLine("Release has started.");

        if (_sprint.Pipeline.Execute(failRelease))
        {
            _sprint.ChangeState(new ReleaseDone(_sprint));
            _sprint.Notify("Release has been completed.", ["Scrum Master", "Product Owner"]);
        }
        else
        {
            _sprint.ChangeState(new SprintFinished(_sprint));
            _sprint.Notify("Release has failed.", ["Scrum Master"]);
        }
    }
    
    public override void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }
}