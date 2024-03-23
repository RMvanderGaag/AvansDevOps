namespace AvansDevOps;

public class SprintClosed : ISprintState
{
    private Sprint _sprint;
    
    public SprintClosed(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been closed.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while sprint is closed.");
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