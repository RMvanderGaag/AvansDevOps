namespace AvansDevOps;

public class Project : IProject, IObserver
{
    public string Name { get; set; }
    private List<Sprint> _sprints = new List<Sprint>();
    private User _productOwner;
        
    public Project(string name, User productOwner)
    {
        Name = name;
        _productOwner = productOwner;
    }
        
    public void AddSprint(Sprint sprint)
    {
        foreach (var backlogItem in sprint.BacklogItems)
        {
            backlogItem.Attach(this);
        }
        
        _sprints.Add(sprint);
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
        }else if (subject.State is Testing)
        {
            var master = _memberships.Where(m => m.Value.Name.Equals("Scrum Master")).Select(m => m.Key).First();
            master.NotificationService.SendNotification($"Notifying {master.Name}: backlog item {subject.GetName()} is back in Todo. Blame {subject.AssignedTo?.Name}.");
        }
        
    }

    public UserRole GetUserWithRole(string name)
    {
        return _memberships.Where(m => m.Key.Name == name).Select(m => m.Value).First();
    }
}