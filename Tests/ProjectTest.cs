using AvansDevOps;

namespace Tests;

[Collection("Collection")]
public class ProjectTest
{
    [Fact]
    public void ProjectCanBeCreated()
    {
        var Project = new Project("Project 1", new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));
        
        Assert.NotNull(Project);
        
        Assert.NotNull(Project.GetProductOwner());
    }

    [Fact]
    public void ProjectCanAddSprint()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        Assert.Contains(sprint, Project.GetSprints());
    }

    [Fact]
    public void ProjectHasVersionControlSystem()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));
        
        Project.AddSprint(sprint);
        
        Assert.NotNull(Project.GitAdapter);
    }

    [Fact]
    public void ProjectCanCommit()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);
        
        var backlogItem = new BacklogItem("Create a new thread");
        
        sprint.AddBacklogItem(backlogItem);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        Project.Commit(backlogItem);
        
        Assert.Contains("Committing changes to the repository.", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void ProjectCanPush()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        var backlogItem = new BacklogItem("Create a new thread");

        sprint.AddBacklogItem(backlogItem);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        Project.Push();

        Assert.Contains("Pushing changes to the repository.", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void ProjectCanPull()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        var backlogItem = new BacklogItem("Create a new thread");

        sprint.AddBacklogItem(backlogItem);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        Project.Pull();

        Assert.Contains("Pulling changes from the repository.", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void ProjectCanMerge()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        var backlogItem = new BacklogItem("Create a new thread");

        sprint.AddBacklogItem(backlogItem);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        Project.Merge();

        Assert.Contains("Merging changes from the repository.", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
    
    [Fact]
    public void ProjectCanCreateBranch()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30),
            new User("Alex Jones", "a.jones@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        var backlogItem = new BacklogItem("Create a new thread");

        sprint.AddBacklogItem(backlogItem);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        Project.Branch();

        Assert.Contains("Creating a new branch in the repository.", sw.ToString());
        
        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}