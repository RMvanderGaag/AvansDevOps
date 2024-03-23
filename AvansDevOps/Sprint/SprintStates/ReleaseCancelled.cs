namespace AvansDevOps;

public class ReleaseCancelled : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseCancelled(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Release has been cancelled.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while release is cancelled.");
    }
    
    public void StartRelease(bool failRelease)
    {
        ActionNotAllowed("start");
    }

    public void CancelRelease()
    {
        ActionNotAllowed("cancel");
    }

    public void StartReview()
    {
        ActionNotAllowed("start review");
    }

    public void StartSprint()
    {
        ActionNotAllowed("start sprint");
    }

    public void CloseSprint(string review)
    {
        ActionNotAllowed("close sprint");
    }

    public void CancelSprint()
    {
        ActionNotAllowed("cancel sprint");
    }

    public void FinishSprint()
    {
        ActionNotAllowed("finish sprint");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        ActionNotAllowed("edit sprint");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        ActionNotAllowed("add backlog item to");
    }
}