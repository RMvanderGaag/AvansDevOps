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
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while release is started.");
    }
    
    public void StartRelease(bool failRelease)
    {
        ActionNotAllowed("start release");
    }

    public void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public void StartReview()
    {
        ActionNotAllowed("start review");
    }

    public void StartSprint()
    {
        ActionNotAllowed("start");
    }

    public void CloseSprint(string review)
    {
        ActionNotAllowed("close");
    }

    public void CancelSprint()
    {
        ActionNotAllowed("cancel");
    }

    public void FinishSprint()
    {
        ActionNotAllowed("finish");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        ActionNotAllowed("edit");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        ActionNotAllowed("add backlog item to");
    }
}