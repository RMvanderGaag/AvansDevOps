namespace AvansDevOps;

public class ReleaseCancelled : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseCancelled(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Release has been cancelled.");
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