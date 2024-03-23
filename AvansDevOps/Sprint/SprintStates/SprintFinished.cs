namespace AvansDevOps;

public class SprintFinished : ISprintState
{
    private Sprint _sprint;
    
    public SprintFinished(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has finished.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while sprint is finished.");
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
        _sprint.Notify("Sprint has been cancelled.", ["Scrum Master"]);
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

    public void StartRelease(bool failRelease)
    {
        _sprint.ChangeState(new ReleaseStarted(_sprint, failRelease));
    }

    public void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public void StartReview()
    {
        _sprint.ChangeState(new SprintReviewing(_sprint));
    }
}