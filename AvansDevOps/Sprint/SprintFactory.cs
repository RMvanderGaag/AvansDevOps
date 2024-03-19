namespace AvansDevOps;

public class SprintFactory
{
    public static Sprint CreateSprint(string sprintType)
    {
        switch (sprintType)
        {
            case "Review":
                return new ReviewSprint();
            case "Deployment":
                return new DeploymentSprint();
            default:
                throw new ArgumentException("Invalid sprint type", nameof(sprintType));
        }
    }
}