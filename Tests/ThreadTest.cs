using AvansDevOps;
using Thread = AvansDevOps.Thread;

namespace Tests;

[Collection("Collection")]
public class ThreadTest
{
    [Fact]
    public void DiscussionHasBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Create a new thread");

        // Act
        var thread = new Thread(backlogItem);

        // Assert
        Assert.Equal(backlogItem, thread.GetBacklogItem());
    }
    
    [Fact]
    public void DiscussionCanAddComment()
    {
        // Arrange
        var backlogItem = new BacklogItem("Create a new thread");
        var thread = new Thread(backlogItem);
        var comment = new Comment("piet", "This is a comment");
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30), new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));
        sprint.AddBacklogItem(backlogItem);
        // Act
        thread.AddComment(comment);

        // Assert
        Assert.Contains(comment, thread.GetComments());
    }

    [Fact]
    public void DiscussionCannotAddCommentToDoneBacklogItem()
    {
        // Arrange
        var backlogItem = new BacklogItem("Create a new thread");
        var thread = new Thread(backlogItem);
        var comment = new Comment("piet", "This is a comment");
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));
        sprint.AddBacklogItem(backlogItem);
        
        backlogItem.TransitionToNextState();
        backlogItem.Complete();
        backlogItem.Test("Tester", true);
        backlogItem.Check("Scrum Master", true);
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            thread.AddComment(comment);

            // Assert
            string expectedOutput = "Cannot add a thread to a done backlog item.";
            Assert.Contains(expectedOutput, sw.ToString());
            Assert.DoesNotContain(comment, thread.GetComments());
            
            sw.Flush();
        }

        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void DiscussionNotifiesProjectMembersWhenCommentIsAdded()
    {
        // Arrange
        var backlogItem = new BacklogItem("Create a new thread");
        var thread = new Thread(backlogItem);
        var comment = new Comment("piet", "This is a comment");
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        var user1 = new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]);
        var user2 = new User("Jan Smit", "j.smit@mail.com", [new EmailNotificationService()]);
        
        sprint.AddMember(user1, new UserRole("Developer"));
        sprint.AddMember(user2, new UserRole("Developer"));
        
        sprint.AddBacklogItem(backlogItem);
        
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            
            // Act
            thread.AddComment(comment);

            string expectedOutput = $"New comment added to backlog item '{backlogItem.GetName()}'!";
            string a = sw.ToString();
            Assert.Contains(expectedOutput, sw.ToString());
            
            sw.Flush();
        }

        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}