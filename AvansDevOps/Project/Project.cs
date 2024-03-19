namespace AvansDevOps;

public class Project : IProject
{
public string Name { get; set; }
private Dictionary<User, UserRole> _memberships = new Dictionary<User, UserRole>();
private List<Sprint> _sprints = new List<Sprint>();
    
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
}