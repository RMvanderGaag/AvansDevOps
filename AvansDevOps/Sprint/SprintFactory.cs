namespace AvansDevOps;

public class SprintFactory
{
    public static Sprint CreateSprint(string sprintType, string name, DateTime startDate, DateTime endDate, User scrumMaster)
    {
        switch (sprintType)
        {
            case "Review":
                return new ReviewSprint(name, startDate, endDate, scrumMaster);
            case "Release":
                return new ReleaseSprint(name, startDate, endDate, scrumMaster);
            default:
                throw new ArgumentException("Invalid sprint type", nameof(sprintType));
        }
    }
}