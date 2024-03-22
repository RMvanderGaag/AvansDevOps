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
        throw new NotImplementedException();
    }

    public void CloseSprint(string review)
    {
        throw new NotImplementedException();
    }
    
    public void CancelSprint()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void CancelRelease()
    {
        throw new NotImplementedException();
    }

    public void StartReview()
    {
        throw new NotImplementedException();
    }
}