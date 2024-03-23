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
        Console.WriteLine("Can't add a subtask to a backlog item that is ready for testing.");
    }

    public void RemoveSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't remove a subtask from a backlog item that is ready for testing.");
    }

    public void Complete(List<Subtask> tasks)
    {
        Console.WriteLine("Can't complete a backlog item that is ready for testing.");
    }

    public void Test(bool isCorrect)
    {
        Console.WriteLine("Can't test a backlog item that is ready for testing.");
    }

    public void Check(bool isCorrect)
    {
        Console.WriteLine("Can't check a backlog item that is ready for testing.");
    }

    public void TransitionToNextState()
    {
        _backlogItem.ChangeState(new Testing(_backlogItem));
    }
}