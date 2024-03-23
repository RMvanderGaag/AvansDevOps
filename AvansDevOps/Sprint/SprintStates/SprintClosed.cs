namespace AvansDevOps;

public class SprintClosed : ISprintState
{
    private Sprint _sprint;
    
    public SprintClosed(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been closed.");
    }
    
    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while sprint is closed.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Sprint is already closed, you can't close it anymore.");
    }
    
    public void CancelSprint()
    {
        Console.WriteLine("Sprint is already closed, you can't cancel it anymore.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Sprint is already closed, you can't finish it anymore.");
    }
    
    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Sprint is already closed, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint is already closed, you can't add backlog items anymore.");
    }

    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't release a sprint while sprint is closed.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release while sprint is closed.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a sprint while sprint is closed.");
    }
}