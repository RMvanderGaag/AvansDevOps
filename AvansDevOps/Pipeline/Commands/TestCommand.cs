namespace AvansDevOps;

public class TestCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Testing the project");
    }
}