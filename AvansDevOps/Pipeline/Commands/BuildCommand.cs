namespace AvansDevOps;

public class BuildCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Building the project");
    }
}