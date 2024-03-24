using AvansDevOps;

namespace Tests.Backlog;

[Collection("Collection")]
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
    public void TestingBacklogItemThatHasTodoState_PrintsErrorMessage()
    {
        var backlogItem = new BacklogItem("Test");
        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogItem.Test("Tester", true);

            // Assert
            string expectedOutput = "Can't test a backlog item that has not been started yet.";
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
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
            
            sw.Flush();
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
    
    [Fact]
    public void CheckNotificationWhenBacklogItemIsMovedToTodo_PrintErrorMessage()
    {
        var sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(10), new User("Scrum Master", "scrum@gmail.com", [new EmailNotificationService()]));
        var backlogitem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogitem);
        backlogitem.AssignTo(testDeveloper);
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Test("Tester", false);

            // Assert
            string expectedOutput = $"Backlog item '{backlogitem.GetName()}' did not pass the test! Blame: {backlogitem.AssignedTo?.Name}";
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
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
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void CheckBacklogItemWhenStateWontLetIt_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Check("Scrum Master", true);

            // Assert
            string expectedOutput = "Can't check a backlog item that is ready for testing.";
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void CheckBacklogItemWithIncorrectRole_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new ReadyForTesting(backlogitem));
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Check("Developer", true);

            // Assert
            string expectedOutput = "Only a scrum master can check a backlog item.";
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void CheckBacklogItemAndFailTest_ChangeStateToReadyForTesting()
    {
        var sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(10), new User("Scrum Master", "scrum@gmail.com", [new EmailNotificationService()]));
        var backlogitem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogitem);
        backlogitem.AssignTo(testDeveloper);
        
        // Act
        backlogitem.ChangeState(new Tested(backlogitem));
        backlogitem.Check("Scrum Master", false);
        
        // Assert
        Assert.IsType<ReadyForTesting>(backlogitem.State);
    }

    [Fact]
    public void CheckBacklogItemAndPassTest_ChangeStateToDone()
    {
        var sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(10),
            new User("Scrum Master", "scrum@gmail.com", [new EmailNotificationService()]));
        var backlogitem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogitem);
        backlogitem.AssignTo(testDeveloper);

        // Act
        backlogitem.ChangeState(new Tested(backlogitem));
        backlogitem.Check("Scrum Master", true);

        // Assert
        Assert.IsType<Done>(backlogitem.State);
    }

    [Fact]
    public void CompleteBacklogItemWhenSubtasksAreNotDone_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.AddSubtask(new Subtask("Test Subtask"));
        backlogitem.ChangeState(new Doing(backlogitem));
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Complete();

            // Assert
            string expectedOutput = "Backlog item cannot be completed because some backlog items are not done yet.";
            Assert.Contains(expectedOutput, sw.ToString());
            Assert.IsType<Doing>(backlogitem.State);
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void CompleteBacklogItemWhenSubtasksAreDone_ChangesStateToReadyForTesting()
    {
        var sprint = new ReviewSprint("Test Sprint", DateTime.Now, DateTime.Now.AddDays(10), new User("Scrum Master", "scrum@gmail.com", [new EmailNotificationService()]));
        var backlogitem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogitem);
        backlogitem.AddSubtask(new Subtask("Test Subtask"));
        backlogitem.ChangeState(new Doing(backlogitem));
        backlogitem.GetTasks().ForEach(t => t.Complete());
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.Complete();

            // Assert
            string expectedOutput = "Backlog item is now completed.";
            Assert.Contains(expectedOutput, sw.ToString());
            Assert.IsType<ReadyForTesting>(backlogitem.State);
            
            sw.Flush();
        }
        
        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void AddSubtaskToBacklogItemWhileInTestingState_PrintsErrorMessage()
    {
        var backlogitem = new BacklogItem("Test");
        backlogitem.ChangeState(new Testing(backlogitem));
        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogitem.AddSubtask(new Subtask("Test Subtask"));

            // Assert
            string expectedOutput = "Can't add a subtask to a backlog item that is being tested.";
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
        }

        // Reset the console output to avoid affecting other tests
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}