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
        Console.WriteLine("Can't start a release that has already ended.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release that has already ended.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a release that has already ended.");
    }

    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint that has already started.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint that has already started.");
    }

    public void CancelSprint()
    {
        Console.WriteLine("Can't cancel a sprint that has already started.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Can't finish a sprint that has already started.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Can't edit a sprint that has already started.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Can't add a backlog item to a sprint that has already started.");
    }
}