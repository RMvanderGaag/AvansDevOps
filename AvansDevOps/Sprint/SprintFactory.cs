namespace AvansDevOps;

public class SprintFactory
{
    public static Sprint CreateSprint(string sprintType, string name)
    {
        switch (sprintType)
        {
            case "Review":
                return new ReviewSprint(name);
            case "Deployment":
                return new DeploymentSprint(name);
            default:
                throw new ArgumentException("Invalid sprint type", nameof(sprintType));
        }
    }
}