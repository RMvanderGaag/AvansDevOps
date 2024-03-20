namespace AvansDevOps;

public class ReadyForTesting : IBacklogItemState
{
    private BacklogItem _backlogItem;
    
    public ReadyForTesting(BacklogItem backlogItem) 
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

    public void TransitionToNextState()
    {
        throw new NotImplementedException();
    }
}