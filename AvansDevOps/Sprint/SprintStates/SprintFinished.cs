namespace AvansDevOps;

public class SprintFinished : ISprintState
{
    private Sprint _sprint;
    
    public SprintFinished(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has finished.");
    }
    
    public void StartSprint()
    {
        Console.WriteLine("Can't start a sprint while sprint is finished.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while sprint is finished.");
    }
    
    public void CancelSprint()
    {
        _sprint.Notify("Sprint has been cancelled.", ["Scrum Master"]);
    }

    public void FinishSprint()
    {
        Console.WriteLine("Sprint has already been finished.");
    }
    
    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Sprint has already been finished, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint has already been finished, you can't add backlog items anymore.");
    }

    public void StartRelease(bool failRelease)
    {
        _sprint.ChangeState(new ReleaseStarted(_sprint, failRelease));
    }

    public void CancelRelease()
    {
        _sprint.ChangeState(new ReleaseCancelled(_sprint));
    }

    public void StartReview()
    {
        _sprint.ChangeState(new SprintReviewing(_sprint));
    }
}