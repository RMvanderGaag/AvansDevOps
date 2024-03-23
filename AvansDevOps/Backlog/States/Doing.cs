namespace AvansDevOps;

public class Doing : IBacklogItemState
{
    private BacklogItem _backlogItem;

    public Doing(BacklogItem backlogItem) 
    {
        _backlogItem = backlogItem;
    }
    
    public void AddSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't add a subtask to a backlog item that is doing.");
    }

    public void RemoveSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't remove a subtask from a backlog item that is doing.");
    }

    public void Complete(List<Subtask> tasks)
    {
        if (tasks.All(t => t.IsComplete) || tasks.Count == 0)
        {
            _backlogItem.IsComplete = true;
            Console.WriteLine($"Backlog item is now completed.");
            TransitionToNextState();
        }
        else
        {
            Console.WriteLine($"Backlog item cannot be completed because some backlog items are not done yet.");
        }
    }

    public void Test(bool isCorrect)
    {
        Console.WriteLine("Can't test a backlog item that is doing.");
    }

    public void Check(bool isCorrect)
    {
        Console.WriteLine("Can't check a backlog item that is doing.");
    }

    public void TransitionToNextState()
    {
        if (_backlogItem.IsComplete)
        {
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
            _backlogItem.Sprint.Notify($"Backlog item '{_backlogItem.GetName()}' is ready for testing!", ["Tester"]);
        }
        else
        {
            Console.WriteLine("Backlog item is not complete yet, cannot transition to next state.");
        }
    }
}