namespace AvansDevOps;

public abstract class Sprint
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    protected ISprintState CurrentState;
    public List<BacklogItem> BacklogItems { get; } = new List<BacklogItem>();
    private Dictionary<User, UserRole> _memberships = new Dictionary<User, UserRole>();
    private User _scrumMaster;


    public Sprint(string name, DateTime startDate, DateTime endDate, User scrumMaster)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        _scrumMaster = scrumMaster;
        CurrentState = new SprintCreated(this);
    }
    
    public void AddMember(User user, UserRole role)
    {
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
    
    public void Update(BacklogItem subject)
    {
        if (subject.State is ReadyForTesting)
        {
            var testers = _memberships.Where(m => m.Value.Name.Equals("Tester")).Select(m => m.Key);
            foreach (var tester in testers)
            {
                tester.NotificationService.SendNotification($"Notifying {tester.Name}: backlog item {subject.GetName()} is ready for testing.");
            }
        }
        else if (subject.State is Testing)
        {
            var master = _memberships.Where(m => m.Value.Name.Equals("Scrum Master")).Select(m => m.Key).First();
            master.NotificationService.SendNotification($"Notifying {master.Name}: backlog item {subject.GetName()} is back in Todo. Blame {subject.AssignedTo?.Name}.");
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
}