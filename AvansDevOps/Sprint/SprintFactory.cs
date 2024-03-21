namespace AvansDevOps;

public class SprintFactory
{
    public static Sprint CreateSprint(string sprintType, string name, DateTime startDate, DateTime endDate, User user)
    {
        switch (sprintType)
        {
            case "Review":
                return new ReviewSprint(name, startDate, endDate, user);
            case "Deployment":
                return new ReleaseSprint(name, startDate, endDate, user);
            default:
                throw new ArgumentException("Invalid sprint type", nameof(sprintType));
        }
    }
}