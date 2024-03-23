namespace AvansDevOps;

public class ReleaseCancelled : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseCancelled(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Release has been cancelled.");
    }
    
    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't start a release that has been cancelled.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Release is already cancelled, you can't cancel it anymore.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review while release is cancelled.");
    }

    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while release is cancelled.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while release is cancelled..");
    }

    public void CancelSprint()
    {
        Console.WriteLine("Can't cancel a sprint while release is cancelled.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Can't finish a sprint while release is cancelled.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Can't edit a sprint while release is cancelled.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Can't add a backlog item to a sprint while release is cancelled.");
    }
}