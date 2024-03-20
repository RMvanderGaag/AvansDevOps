namespace AvansDevOps;

public class SprintFactory
{
    public static Sprint CreateSprint(string sprintType, string name, DateTime startDate, DateTime endDate)
    {
        switch (sprintType)
        {
            case "Review":
                return new ReviewSprint(name, startDate, endDate);
            case "Deployment":
                return new DeploymentSprint(name, startDate, endDate);
            default:
                throw new ArgumentException("Invalid sprint type", nameof(sprintType));
        }
    }
}