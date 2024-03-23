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
        Console.WriteLine("Can't add a subtask to a backlog item that is done.");
    }

    public void RemoveSubtask(Subtask subtask)
    {
        Console.WriteLine("Can't remove a subtask from a backlog item that is done.");
    }

    public void Complete(List<Subtask> tasks)
    {
        Console.WriteLine("Can't complete a backlog item that is done.");
    }

    public void Test(bool isCorrect)
    {
        Console.WriteLine("Can't test a backlog item that is done.");
    }

    public void Check(bool isCorrect)
    {
        Console.WriteLine("Can't check a backlog item that is done.");
    }

    public void TransitionToNextState()
    {
        Console.WriteLine("Can't transition to the next state, backlog item is already done.");
    }
}