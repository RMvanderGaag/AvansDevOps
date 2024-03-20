namespace AvansDevOps;

public class SprintStarted : ISprintState
{
    private Sprint _sprint;
    public SprintStarted(Sprint sprint)
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
        Console.WriteLine("Sprint has already started, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint has already started, you can't add backlog items anymore.");
    }
}