namespace AvansDevOps;

public class Done : IBacklogItemState
{
    private BacklogItem _backlogItem;
    
    public Done(BacklogItem backlogItem) 
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
        throw new NotImplementedException();
    }

    public void TransitionToNextState()
    {
        throw new NotImplementedException();
    }
}