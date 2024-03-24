using AvansDevOps;

namespace Tests;

[Collection("Collection")]
public class PipelineTest
{
    [Fact]
    public void SprintHasPipeline()
    {
        var Project = new Project("Project 1", new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));
        var sprint = new ReviewSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(30), new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));
        
        Project.AddSprint(sprint);

        Assert.NotNull(sprint.Pipeline);
    }

    [Fact]
    public void PipelineExecutes()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));
        var sprint = new ReviewSprint("Sprint 1", new DateTime(2024, 3, 21), new DateTime(2024, 3, 22),
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);
        
        sprint.StartSprint();
        sprint.FinishSprint();
        
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            sprint.StartRelease(false);
            
            Assert.Contains("Pipeline has been completed.", sw.ToString());
            Assert.Contains("Release has been completed.", sw.ToString());
        }

        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void PipelineExecutesWithErrors()
    {
        var Project = new Project("Project 1",
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));
        var sprint = new ReviewSprint("Sprint 1", new DateTime(2024, 3, 21), new DateTime(2024, 3, 22),
            new User("John Doe", "j.doe@mail.com", [new EmailNotificationService()]));

        Project.AddSprint(sprint);

        sprint.StartSprint();
        sprint.FinishSprint();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            sprint.StartRelease(true);

            Assert.Contains("Pipeline failed. Try again!", sw.ToString());
            Assert.Contains("Release has failed.", sw.ToString());
        }

        // Reset the console output
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}