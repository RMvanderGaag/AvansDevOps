namespace AvansDevOps;

public class Testing : IBacklogItemState
{
    private BacklogItem _backlogItem;
    
    public Testing(BacklogItem backlogItem) 
    {
        _backlogItem = backlogItem;
    }
    
    public void AddSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't add a subtask to a backlog item that is being tested.");
    }

    public void RemoveSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't remove a subtask from a backlog item that is being tested.");
    }

    public void Complete(List<Subtask> tasks)
    {
        Console.WriteLine("Can't complete a backlog item that is being tested.");
    }

    public void Test(bool isCorrect)
    {
        if (isCorrect)
        {
            TransitionToNextState();
        }
        else
        {
            _backlogItem.Sprint.Notify($"Backlog item '{_backlogItem.GetName()}' did not pass the test! Blame: {_backlogItem.AssignedTo?.Name}", ["Scrum Master"]);
            _backlogItem.ChangeState(new Todo(_backlogItem));
        }
    }

    public void Check(bool isCorrect)
    {
        Console.WriteLine("Can't check a backlog item that is being tested.");
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Tested(_backlogItem));
    }
}