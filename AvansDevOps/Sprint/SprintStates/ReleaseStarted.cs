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
        Console.WriteLine("Can't start a release that has already started.");
    }

    public void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a release that has not ended yet.");
    }

    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint that has already started.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint that has not ended yet.");
    }

    public void CancelSprint()
    {
        Console.WriteLine("Can't cancel a sprint that has already started.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Can't finish a sprint that has not ended yet.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Can't edit a sprint that has already started.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Can't add a backlog item to a sprint that has already started.");
    }
}