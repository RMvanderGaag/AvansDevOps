namespace AvansDevOps;

public class Pipeline
{
    private readonly List<ICommand> _commands = new List<ICommand>();
    private readonly Sprint _sprint;

    public Pipeline(Sprint sprint)
    {
        _sprint = sprint;
    }
    
    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }
    
    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}