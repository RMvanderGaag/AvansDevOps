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
        throw new NotImplementedException();
    }

    public void RemoveSubtask(Subtask subtask)
    {
        throw new NotImplementedException();
    }

    public void Complete(List<Subtask> tasks)
    {
        if (tasks.All(t => t.IsComplete) || tasks.Count == 0)
        {
            _backlogItem.IsComplete = true;
            Console.WriteLine($"Backlog item is now completed.");
        }
        else
        {
            Console.WriteLine($"Backlog item cannot be completed because some backlog items are not done yet.");
        }
    }

    public void TransitionToNextState()
    {
        if (_backlogItem.IsComplete)
        {
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
            _backlogItem.Notify();
        }
        else
        {
            Console.WriteLine("Backlog item is not complete yet, cannot transition to next state.");
        }
    }
}