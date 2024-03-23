namespace AvansDevOps;

public class Tested : IBacklogItemState
{
    private BacklogItem _backlogItem;
    
    public Tested(BacklogItem backlogItem) 
    {
        _backlogItem = backlogItem;
    }
    
    public void AddSubtask(Subtask subtask)
    {
        throw new NotImplementedException();
    }

    public void RemoveSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't remove a subtask from a backlog item that has been tested.");
    }

    public void Complete(List<Subtask> tasks)
    {
        Console.WriteLine("Can't complete a backlog item that has been tested.");
    }

    public void Test(bool isCorrect)
    {
        Console.WriteLine("Can't test a backlog item that has been tested.");
    }

    public void Check(bool isCorrect)
    {
        if (isCorrect)
        {
            TransitionToNextState();
        }
        else
        {
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
            _backlogItem.Sprint.Notify($"Backlog item '{_backlogItem.GetName()}' is ready for testing!", ["Tester"]);
        }
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Done(_backlogItem));
    }
}