namespace AvansDevOps;

public class SprintPerformed : ISprintState
{
    private Sprint _sprint;
    // TODO: question: what is the performed state?
    public SprintPerformed(Sprint sprint)
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