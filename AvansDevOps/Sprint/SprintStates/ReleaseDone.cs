namespace AvansDevOps;

public class ReleaseDone : ISprintState
{
    private Sprint _sprint;
    
    public ReleaseDone(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Release has been completed.");
    }
    
    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't start a release while release is done.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release while release is done.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a release while release is done.");
    }

    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while release is done.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while release is done.");
    }

    public void CancelSprint()
    {
        Console.WriteLine("Can't cancel a sprint while release is done.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Can't finish a sprint while release is done.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Can't edit a sprint while release is done.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Can't add a backlog item to a sprint while release is done.");
    }
}