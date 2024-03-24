using AvansDevOps;

namespace Tests.Backlog;

public class BacklogItemTest
{
    private BacklogItem _backlogItem = new BacklogItem("Test");
    private User testDeveloper = new User("Test Developer", "test@example.com", [new EmailNotificationService()]);
    
    [Fact]
    public void AssignUserToBacklogItem()
    {
        _backlogItem.AssignTo(testDeveloper);
        
        Assert.Equal(testDeveloper, _backlogItem.AssignedTo);
    }
    
    [Fact]
    public void TestingBacklogItemNotReadyForTesting_PrintsErrorMessage()
    {
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            _backlogItem.Test("Tester", true);

            // Assert
            string expectedOutput = "Can't test a backlog item that is not ready for testing.";
            Assert.Contains(expectedOutput, sw.ToString());
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void TestingBacklogItemWithIncorrectRole_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Test("Developer", true);

            // Assert
            string expectedOutput = "Only a tester can test a backlog item.";
            Assert.Contains(expectedOutput, sw.ToString());
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void TestingBacklogItemWithCorrectRole_TransitionsToNextState()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        backlogitem.Test("Tester", true);
        
        Assert.IsType<Tested>(backlogitem.State);
    }
    
    // TODO: test if scrum master receives a notification when a backlog item is being moved to the todo state.
    
    [Fact]
    public void CompleteBacklogItemWhenStateWontLetIt_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Complete();

            // Assert
            string expectedOutput = "Can't complete a backlog item that is ready for testing.";
            Assert.Contains(expectedOutput, sw.ToString());
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}