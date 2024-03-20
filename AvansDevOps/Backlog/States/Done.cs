namespace AvansDevOps;

public class Done : IBacklogItemState
{
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