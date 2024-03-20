namespace AvansDevOps;

public class SprintPipelineStarted : ISprintState
{
    private Sprint _sprint;
    
    public SprintPipelineStarted(Sprint sprint)
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
        Console.WriteLine("Sprint pipeline has already been started, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint pipeline has already been started, you can't add backlog items anymore.");
    }
}