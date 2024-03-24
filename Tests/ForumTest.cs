using AvansDevOps;
using Thread = AvansDevOps.Thread;

namespace Tests;

public class ForumTest
{
    [Fact]
    public void AddThread_ActiveBacklogItem_AddsThreadSuccessfully()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), new User("John Doe", "john@mail.com", new List<INotificationService>()));
        var forum = new Forum();
        var backlogItem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogItem);
        var user = new User("Arie Bakker", "arie@bakker.nl", new List<INotificationService>());
        var thread = new Thread(backlogItem);        
        thread.AddComment(new Comment(user.Name, "LGTM!"));
        
        // Act
        forum.AddThread(thread);

        // Assert
        Assert.Contains(thread, forum.GetThreads());
    }

    [Fact]
    public void AddThread_DoneBacklogItem_ThrowsException()
    {
        // Arrange
        var forum = new Forum();
        var doneBacklogItem = new BacklogItem("Nieuwe test backlog item");
        doneBacklogItem.ChangeState(new Done(doneBacklogItem));
        var thread = new Thread(doneBacklogItem);

        // Act & Assert
        var exception = Assert.Throws<Exception>(() => forum.AddThread(thread));
        Assert.Equal("Cannot add thread to forum, backlog item is done.", exception.Message);
    }

    [Fact]
    public void AddComment_ActiveBacklogItem_AddsCommentSuccessfully()
    {
        // Arrange
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14),
            new User("John Doe", "john@mail.com", new List<INotificationService>()));
        var forum = new Forum();
        var backlogItem = new BacklogItem("Test");
        sprint.AddBacklogItem(backlogItem);
        var user = new User("Arie Bakker", "arie@bakker.nl", new List<INotificationService>());
        var thread = new Thread(backlogItem);
        var comment = new Comment(user.Name, "LGTM!");

        // Act
        thread.AddComment(comment);

        // Assert
        Assert.Contains(comment, thread.GetComments());
    }
}