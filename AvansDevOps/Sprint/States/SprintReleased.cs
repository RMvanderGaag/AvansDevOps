namespace AvansDevOps;

public class SprintReleased : ISprintState
{
    private Sprint _sprint;
    
    public SprintReleased(Sprint sprint)
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