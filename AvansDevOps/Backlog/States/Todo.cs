namespace AvansDevOps;

public class Todo : IBacklogItemState
{
    private BacklogItem _backlogItem;
    private List<Subtask> _tasks;

    public Todo(BacklogItem backlogItem) 
    {
        _backlogItem = backlogItem;
        _tasks = _backlogItem.GetTasks();
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
        Console.WriteLine("Can't complete a backlog item that has not been started yet.");
    }

    public void Test(bool isCorrect)
    {
        Console.WriteLine("Can't test a backlog item that has not been started yet.");
    }

    public void Check(bool isCorrect)
    {
        Console.WriteLine("Can't check a backlog item that has not been started yet.");
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Doing(_backlogItem));
    }
}