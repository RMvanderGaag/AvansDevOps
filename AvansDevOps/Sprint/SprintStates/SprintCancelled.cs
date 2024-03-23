namespace AvansDevOps;

public class SprintCancelled : ISprintState
{
    private Sprint _sprint;
    
    public SprintCancelled(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been cancelled.");
    }
    
    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while sprint is cancelled.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while sprint is cancelled.");
    }
    
    public void CancelSprint()
    {
        Console.WriteLine("Sprint is already cancelled, you can't cancel it anymore.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Sprint is cancelled, you can't finish it anymore.");
    }
    
    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Sprint is cancelled, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint is cancelled, you can't add backlog items anymore.");
    }

    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't release a sprint while sprint is cancelled.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release while sprint is cancelled.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a sprint while sprint is cancelled.");
    }
}