namespace AvansDevOps;

public class SprintCreated : ISprintState
{
    private Sprint _sprint;
    
    public SprintCreated(Sprint sprint)
    {
        this._sprint = sprint;
    }
    
    public void StartSprint()
    {
        _sprint.ChangeState(new SprintPerformed(_sprint));
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
}