namespace AvansDevOps;

public class UserRole
{
    public string Name { get; set; }
    private List<UserPermission> _permissions = new List<UserPermission>();
    
    public UserRole(string name)
    {
        Name = name;
    }
    
    public void AddPermission(UserPermission permission)
    {
        _permissions.Add(permission);
    }
    
    public bool HasPermission(string permissionName)
    {
        return _permissions.Any(p => p.Name == permissionName);
    }
}