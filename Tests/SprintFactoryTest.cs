using AvansDevOps;

namespace Tests;

public class SprintFactoryTest
{
    private UserRole developerRole = new UserRole("Developer");
    private UserRole testerRole = new UserRole("Tester");
    private UserRole productOwnerRole = new UserRole("Product Owner");
    private UserRole scrumMasterRole = new UserRole("Scrum Master");
    
    private User testDeveloper = new User("Test Developer", "test@example.com", [new EmailNotificationService()]);
    private User scrumMaster = new User("Scrum Master", "scrum@example.com", [new EmailNotificationService()]);

    public SprintFactoryTest()
    {
        Initialize();
    }
    
    public void Initialize()
    {
        scrumMasterRole.AddPermission(new UserPermission("CloseSprint"));
    }
    
    [Fact]
    public void CreateSprint_ReturnsReviewSprint_WhenTypeIsReview()
    {
        var sprint = SprintFactory.CreateSprint("Review", "Review Sprint", DateTime.Now, DateTime.Now.AddDays(30), scrumMaster);

        // Assert
        Assert.NotNull(sprint);
        Assert.IsType<ReviewSprint>(sprint);
        Assert.Equal("Review Sprint", sprint.Name);
    }

    [Fact]
    public void CreateSprint_ReturnsReleaseSprint_WhenTypeIsRelease()
    {
        var sprint = SprintFactory.CreateSprint("Release", "Release Sprint", DateTime.Now, DateTime.Now.AddDays(30), scrumMaster);
        
        // Assert
        Assert.NotNull(sprint);
        Assert.IsType<ReleaseSprint>(sprint);
        Assert.Equal("Release Sprint", sprint.Name);
    }
}