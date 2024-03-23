namespace AvansDevOps;

public class ReleaseStarted : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseStarted(Sprint sprint, bool failRelease)
    {
        this._sprint = sprint;

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
    
    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't start a release while release has already started.");
    }

    public void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review while release is started.");
    }

    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while release is started.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while release is started.");
    }

    public void CancelSprint()
    {
        Console.WriteLine("Can't cancel a sprint while release is started.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Can't finish a sprint while release is started.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Can't edit a sprint while release is started.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Can't add a backlog item to a sprint while release is started.");
    }
}