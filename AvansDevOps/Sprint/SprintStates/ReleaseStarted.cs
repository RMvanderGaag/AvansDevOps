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
        throw new NotImplementedException();
    }

    public void CancelRelease()
    {
        throw new NotImplementedException();
    }

    public void StartReview()
    {
        throw new NotImplementedException();
    }

    public void StartSprint()
    {
        throw new NotImplementedException();
    }

    public void CloseSprint(string review)
    {
        throw new NotImplementedException();
    }

    public void CancelSprint()
    {
        throw new NotImplementedException();
    }

    public void FinishSprint()
    {
        throw new NotImplementedException();
    }

    public void EditSprint(Sprint updatedSprint)
    {
        throw new NotImplementedException();
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }
}