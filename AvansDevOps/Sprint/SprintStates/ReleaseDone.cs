namespace AvansDevOps;

public class ReleaseDone : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseDone(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Release has been completed.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while release is done.");
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