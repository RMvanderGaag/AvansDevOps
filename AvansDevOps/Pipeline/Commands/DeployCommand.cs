namespace AvansDevOps;

public class DeployCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Deploying the project");
    }
}