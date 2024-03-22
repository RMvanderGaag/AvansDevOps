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
        throw new NotImplementedException();
    }

    public void CloseSprint(string review)
    {
        if (string.IsNullOrEmpty(review)) return;
        
        _sprint.ChangeState(new SprintClosed(_sprint));
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
}