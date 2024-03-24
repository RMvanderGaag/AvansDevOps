namespace AvansDevOps;

public class Project : IProject
{
    public string Name { get; set; }
    private List<Sprint> _sprints = new List<Sprint>();
    private User _productOwner;
    public readonly GitAdapter GitAdapter = new GitAdapter();
    
    public void Commit(BacklogItem backlogItem)
    {
        GitAdapter.Commit(backlogItem);
    }
    
    public void Push()
    {
        GitAdapter.Push();
    }
        
    public Project(string name, User productOwner)
    {
        Name = name;
        _productOwner = productOwner;
        
    }

    public void AddSprint(Sprint sprint)
    {
        sprint.AddMember(_productOwner, new UserRole("Product Owner"));
        _sprints.Add(sprint);
    }
    
    public User GetProductOwner()
    {
        return _productOwner;
    }
    
    public List<Sprint> GetSprints()
    {
        return _sprints;
    }
}