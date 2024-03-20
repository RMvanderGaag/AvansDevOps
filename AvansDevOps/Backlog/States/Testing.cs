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
        if (isCorrect)
        {
            TransitionToNextState();
        }
        else
        {
            _backlogItem.Notify();
            _backlogItem.ChangeState(new Todo(_backlogItem));;
        }
    }

    public void Check(bool isCorrect)
    {
        throw new NotImplementedException();
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Tested(_backlogItem));
    }
}