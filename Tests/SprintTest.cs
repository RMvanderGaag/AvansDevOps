using System.Net.Sockets;
using AvansDevOps;

namespace Tests;

[Collection("Collection")]
public class SprintTest
{
    private UserRole developerRole = new UserRole("Developer");
    private UserRole testerRole = new UserRole("Tester");
    private UserRole productOwnerRole = new UserRole("Product Owner");
    private UserRole scrumMasterRole = new UserRole("Scrum Master");
    
    private User testDeveloper = new User("Test Developer", "test@example.com", [new SlackNotificationService()]);
    private User scrumMaster = new User("Scrum Master", "scrum@example.com", [new EmailNotificationService()]);
    
    public SprintTest()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        scrumMasterRole.AddPermission(new UserPermission("CloseSprint"));
    }
    
    [Fact]
    public void CloseSprint_Fails_WhenUserLacksPermission()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(10), scrumMaster);
        sprint.AddMember(testDeveloper, developerRole);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        sprint.CloseSprint(testDeveloper, "Completed");

        // Assert
        string expectedOutput = "Sprint not found or user does not have permission to close sprints.";
        Assert.Contains(expectedOutput, sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void CloseSprint_Succeeds_WhenUserHasPermission()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(10), scrumMaster);
        sprint.ChangeState(new SprintFinished(sprint));
        sprint.StartReview();    
        
        // Act
        sprint.CloseSprint(scrumMaster, "Completed");

        // Assert
        Assert.IsType<SprintClosed>(sprint.GetCurrentState());
    }
    
    [Fact]
    public void StartSprint_ChangesState_WhenCalled()
    {
        // Arrange
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now.AddDays(10), new User("Alex Jones", "alex@gmail.com", [new SlackNotificationService()] ));
        var initialState = sprint.GetCurrentState();

        // Act
        sprint.StartSprint();

        // Assert
        Assert.NotEqual(initialState, sprint.GetCurrentState());
    }

    [Fact]
    public void FinishSprint_ChangesState_WhenCalled()
    {
        // Arrange
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now, testDeveloper);
        sprint.StartSprint();

        // Act
        sprint.FinishSprint();

        // Assert
        Assert.IsType<SprintFinished>(sprint.GetCurrentState());
    }
    
    [Fact]
    public void FinishSprintNotPossibleWhenSprintHasNotEnded_PrintsErrorMessage()
    {
        // Arrange
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now.AddDays(10), testDeveloper);
        sprint.StartSprint();

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        sprint.FinishSprint();

        // Assert
        string expectedOutput = "Sprint has not ended yet.";
        Assert.Contains(expectedOutput, sw.ToString());
            
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void FinishSprintFailsWhenEndDateIsNotReached()
    {
        // Arrange
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now.AddDays(5), testDeveloper);
        sprint.StartSprint();

        // Act
        sprint.FinishSprint();
        
        // Assert
        Assert.IsType<SprintStarted>(sprint.GetCurrentState());
        
    }

    [Fact]
    public void SprintCantChangeState()
    {
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now.AddDays(5), testDeveloper);
        
        sprint.StartReview();
        
        Assert.IsType<SprintCreated>(sprint.GetCurrentState());
    }
}