namespace AvansDevOps;

public class Project : IProject, IObserver
{
public string Name { get; set; }
private Dictionary<User, UserRole> _memberships = new Dictionary<User, UserRole>(); // TODO: move this to sprint because a sprint has members. A project only has a product owner.
private List<Sprint> _sprints = new List<Sprint>();
// TODO: add a product owner as a user property.
    
public Project(string name)
{
    Name = name;
}
    
public void AddMember(User user, UserRole role)
{
    _memberships.Add(user, role);
}

public bool UserHasPermission(User user, string permission)
{
    return _memberships[user].HasPermission(permission);
}
    
public void AddSprint(Sprint sprint)
{
    foreach (var backlogItem in sprint.BacklogItems)
    {
        backlogItem.Attach(this);
    }
    
    _sprints.Add(sprint);
}
    
public void CloseSprint(Sprint sprint, User user)
{
    var sprintResult = _sprints.FirstOrDefault(s => s == sprint);
    if (sprintResult != null && UserHasPermission(user, "CloseSprint"))
    {
        sprint.CloseSprint();
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