namespace AvansDevOps;

public abstract class Sprint
{
    public string Name { get; }
    private ISprintState _currentState;

    public Sprint(string name)
    {
        name = name;
        _currentState = new SprintCreated(this);
    }
    
    // The ChangeState method allows for the transition to a new state.
    public void ChangeState(ISprintState newState)
    {
        _currentState = newState;
        Console.WriteLine($"Sprint {Name} has transitioned to a new state.");
    }
        
    // Actions that can be performed on the sprint. They delegate the action to the current state.
    public void StartSprint()
    {
        _currentState.StartSprint();
    }

    public void CloseSprint()
    {
        _currentState.CloseSprint();
        Console.WriteLine($"Sprint {Name} is now closed.");
    }

    public void CancelSprint()
    {
        _currentState.CancelSprint();
    }

    public void FinishSprint()
    {
        _currentState.FinishSprint();
    }

    public void CreateReport(SprintReportExporter exporter)    
    {
        exporter.ExportReport(this.Name);
    }
}