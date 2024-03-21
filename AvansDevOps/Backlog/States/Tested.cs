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
        throw new NotImplementedException();
    }

    public void Complete(List<Subtask> tasks)
    {
        throw new NotImplementedException();
    }

    public void Test(bool isCorrect)
    {
        throw new NotImplementedException();
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
            _backlogItem.Sprint.Notify($"Backlog item '{_backlogItem.GetName()}' is ready for testing!", "Tester");
        }
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Done(_backlogItem));
    }
}