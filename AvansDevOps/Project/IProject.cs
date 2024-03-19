namespace AvansDevOps;

public interface IProject
{
    void AddMember(User user, UserRole role);
    bool UserHasPermission(User user, string permission);
    void AddSprint(Sprint sprint);
    void CloseSprint(Sprint sprint, User user);
}