namespace AvansDevOps;

public class SprintCancelled : ISprintState
{
    private Sprint _sprint;
    
    public SprintCancelled(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been cancelled.");
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
        Console.WriteLine("Sprint is cancelled, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint is cancelled, you can't add backlog items anymore.");
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