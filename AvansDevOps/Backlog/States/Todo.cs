namespace AvansDevOps;

public class Todo : IBacklogItemState
{
    private BacklogItem _backlogItem;
    private List<Subtask> _tasks;

    public Todo(BacklogItem backlogItem, List<Subtask> tasks) 
    {
        _backlogItem = backlogItem;
        _tasks = tasks;
    }

    public void AddSubtask(Subtask subtask)
    {
        _tasks.Add(subtask);
    }

    public void RemoveSubtask(Subtask subtask)
    {
        _tasks.Remove(subtask);
    }

    public void Complete(List<Subtask> tasks)
    {
        throw new NotImplementedException();
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Doing(_backlogItem));
    }
}