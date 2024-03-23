namespace AvansDevOps;

public class SprintReviewing : ISprintState
{
    private Sprint _sprint;
    
    public SprintReviewing(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint review has started.");
    }
    
    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint that has already started.");
    }

    public void CloseSprint(string review)
    {
        if (string.IsNullOrEmpty(review)) return;
        
        _sprint.ChangeState(new SprintClosed(_sprint));
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

    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't release a sprint that has not ended yet.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release that has not started yet.");
    }

    public void StartReview()
    {
        Console.WriteLine("Sprint review has already started.");
    }
}