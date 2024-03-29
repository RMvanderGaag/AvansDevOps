namespace AvansDevOps;

public class BacklogItem : BacklogComponent, IGitItem
{
    private List<Subtask> _tasks = new List<Subtask>();
    public override bool IsComplete { get; set; } // Why don't we use the State pattern instead of this?
    public IBacklogItemState State;
    public Sprint Sprint;

    public BacklogItem(string name) : base(name)
    {
        State = new Todo(this);
    }
    
    public List<Subtask> GetTasks()
    {
        return _tasks;
    }

    public void ChangeState(IBacklogItemState state)
    {
        State = state;
        Console.WriteLine($"State has been changed to: {state}");
    }
    
    public void AddSubtask(Subtask subtask)
    {
        State.AddSubtask(subtask);
    }

    public void RemoveSubtask(Subtask subtask)
    {
        State.RemoveSubtask(subtask);
    }
    
    public void Complete()
    {
        State.Complete(_tasks);
    }
    
    public void TransitionToNextState()
    {
        State.TransitionToNextState();
    }

    public void Test(string role, bool isCorrect)
    {
        if (!role.Equals("Tester"))
        {
            Console.WriteLine("Only a tester can test a backlog item.");
            return;
        }
        State.Test(isCorrect);
    }
    
    public void Check(string role, bool isCorrect)
    {
        if (!role.Equals("Scrum Master"))
        {
            Console.WriteLine("Only a scrum master can check a backlog item.");
            return;
        }
        State.Check(isCorrect);
    }
    
}