namespace AvansDevOps;

public class SprintFinished : ISprintState
{
    private Sprint _sprint;
    
    public SprintFinished(Sprint sprint)
    {
        this._sprint = sprint;
    }
    
    public void StartSprint()
    {
        throw new NotImplementedException();
    }

    public void CloseSprint()
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
        Console.WriteLine("Sprint has already been finished, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint has already been finished, you can't add backlog items anymore.");
    }

    public void StartRelease()
    {
        Console.WriteLine("Starting release...");
        _sprint.ChangeState(new ReleaseStarted());
    }

    public void CancelRelease()
    {
        Console.WriteLine("Release has been cancelled.");
        _sprint.ChangeState(new ReleaseCancelled());
    }
}