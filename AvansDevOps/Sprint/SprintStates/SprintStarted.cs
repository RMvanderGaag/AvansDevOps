namespace AvansDevOps;

public class SprintStarted : ISprintState
{
    private Sprint _sprint;
    public SprintStarted(Sprint sprint)
    {
        Console.WriteLine("Sprint has started.");
        this._sprint = sprint;
    }
    
    public void StartSprint()
    {
        Console.WriteLine("Sprint has already started.");
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while sprint is started.");
    }
    
    public void CancelSprint()
    {
        Console.WriteLine("Sprint has already started, you can't cancel it anymore.");
    }

    public void FinishSprint()
    {
        if (_sprint.EndDate < DateTime.Now)
        {
            _sprint.ChangeState(new SprintFinished(_sprint));
        }
        else
        {
            Console.WriteLine("Sprint has not ended yet.");
        }
    }

    public void EditSprint(Sprint updatedSprint)
    {
        Console.WriteLine("Sprint has already started, you can't edit it anymore.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        Console.WriteLine("Sprint has already started, you can't add backlog items anymore.");
    }

    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("You can't release a sprint while sprint is started.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("You can't cancel a release while sprint is started.");
    }

    public void StartReview()
    {
        Console.WriteLine("You can't start a review while sprint is started.");
    }
}