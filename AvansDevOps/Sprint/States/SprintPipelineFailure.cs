namespace AvansDevOps;

public class SprintPipelineFailure : ISprintState
{
    private Sprint _sprint;
    
    public SprintPipelineFailure(Sprint sprint)
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
        Console.WriteLine("Sprint pipeline has failed, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint pipeline has failed, you can't add backlog items anymore.");
    }
}