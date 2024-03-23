namespace AvansDevOps;

public class SprintReviewing : ISprintState
{
    private Sprint _sprint;
    
    public SprintReviewing(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint review has started.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while review is ongoing.");
    }
    
    public void StartSprint()
    {
        ActionNotAllowed("start");
    }

    public void CloseSprint(string review)
    {
        if (string.IsNullOrEmpty(review)) return;
        
        _sprint.ChangeState(new SprintClosed(_sprint));
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