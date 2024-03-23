namespace AvansDevOps;

public class SprintStarted : ISprintState
{
    private Sprint _sprint;
    public SprintStarted(Sprint sprint)
    {
        Console.WriteLine("Sprint has started.");
        this._sprint = sprint;
    }

    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while sprint is started.");
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
        if (_sprint.EndDate < DateTime.Now)
        {
            _sprint.ChangeState(new SprintFinished(_sprint));
        }
        else
        {
            Console.WriteLine("Sprint has not ended yet.");
        }
    }

    public void EditSprint(Sprint updatedSprint)
    {
        ActionNotAllowed("edit");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        ActionNotAllowed("add backlog item");
    }

    public void StartRelease(bool failRelease)
    {
        ActionNotAllowed("start release");
    }

    public void CancelRelease()
    {
        ActionNotAllowed("cancel release");
    }

    public void StartReview()
    {
        ActionNotAllowed("start review");
    }
}