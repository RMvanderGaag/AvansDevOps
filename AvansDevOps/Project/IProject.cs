namespace AvansDevOps;

public interface IProject
{
    void AddMember(User user, UserRole role);
    void AddSprint(Sprint sprint);
}