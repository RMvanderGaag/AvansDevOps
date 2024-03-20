namespace AvansDevOps;

public abstract class Sprint
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    protected ISprintState CurrentState;
    // TODO: add a scrum master as a user property.
    public List<BacklogItem> BacklogItems { get; } = new List<BacklogItem>();

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        CurrentState = new SprintCreated(this);
    }
    
    // The ChangeState method allows for the transition to a new state.
    public void ChangeState(ISprintState newState)
    {
        CurrentState = newState;
        Console.WriteLine($"Sprint {Name} has transitioned to a new state.");
    }
        
    // Actions that can be performed on the sprint. They delegate the action to the current state.
    public void StartSprint()
    {
        CurrentState.StartSprint();
    }

    public void CloseSprint()
    {
        CurrentState.CloseSprint();
        Console.WriteLine($"Sprint {Name} is now closed.");
    }

    public void CancelSprint()
    {
        CurrentState.CancelSprint();
    }

    public void FinishSprint()
    {
        CurrentState.FinishSprint();
    }
    
    public void EditSprint(Sprint updatedSprint)
    {
        CurrentState.EditSprint(updatedSprint);
    }
    
    public void AddBacklogItem(BacklogItem backlogItem)
    {
        CurrentState.AddBacklogItem(backlogItem);
    }

    public void CreateReport(SprintReportExporter exporter)    
    {
        exporter.ExportReport(this.Name);
    }
}