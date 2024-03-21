namespace AvansDevOps;

public abstract class Sprint : ISubject
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    protected ISprintState CurrentState;
    public List<BacklogItem> BacklogItems { get; } = new List<BacklogItem>();
    private Dictionary<User, UserRole> _memberships = new Dictionary<User, UserRole>();
    protected User _scrumMaster { get; private set; }
    private List<IObserver> _observers = new List<IObserver>();


    public Sprint(string name, DateTime startDate, DateTime endDate, User scrumMaster)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        _scrumMaster = scrumMaster;
        _memberships.Add(scrumMaster, new UserRole("Scrum Master"));
        CurrentState = new SprintCreated(this);
    }
    
    public void AddMember(User user, UserRole role)
    {
        Attach(user);
        _memberships.Add(user, role);
    }
    
    public bool UserHasPermission(User user, string permission)
    {
        return _memberships[user].HasPermission(permission);
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

    public void CloseSprint(User user)
    {
        if (UserHasPermission(user, "CloseSprint"))
        {
            CurrentState.CloseSprint();
        }
        else
        {
            Console.WriteLine("Sprint not found or user does not have permission to close sprints.");
        }
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

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message, string? role = null)
    {
        var users = _memberships.Keys.ToList();
        if(role != null) users = _memberships.Where(m => m.Value.Name.Equals(role)).Select(m => m.Key).ToList();
        
        
        foreach (var observer in users)
        {
            observer.Update(this, message, observer.Name);
        }
    }
}