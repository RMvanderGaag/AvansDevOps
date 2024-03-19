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
}