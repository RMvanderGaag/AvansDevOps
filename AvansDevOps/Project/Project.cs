namespace AvansDevOps;

public class Project : IProject
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
        _sprints.Add(sprint);
    }
}