namespace AvansDevOps;

public class SprintCreated : ISprintState
{
    private Sprint _sprint;
    
    public SprintCreated(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been created.");
    }
    
    public void StartSprint()
    {
        _sprint.ChangeState(new SprintStarted(_sprint));
    }

    public void CloseSprint(string review)
    {
        Console.WriteLine("Can't close a sprint while sprint is created.");
    }
    
    public void CancelSprint()
    {
        Console.WriteLine("Sprint can't be cancelled while sprint is created.");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Sprint can't be finished while sprint is created.");
    }

    public void EditSprint(Sprint updatedSprint)
    {
        _sprint.Name = updatedSprint.Name;
        _sprint.StartDate = updatedSprint.StartDate;
        _sprint.EndDate = updatedSprint.EndDate;
        Console.WriteLine("Sprint has been updated.");
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        backlogItem.Sprint = _sprint;
        _sprint.BacklogItems.Add(backlogItem);
        Console.WriteLine($"Backlog item has been added to the sprint.");
    }

    public void StartRelease(bool failRelease)
    {
        Console.WriteLine("Can't release a sprint while sprint is created.");
    }

    public void CancelRelease()
    {
        Console.WriteLine("Can't cancel a release while sprint is created.");
    }

    public void StartReview()
    {
        Console.WriteLine("Can't start a review for a sprint while sprint is created.");
    }
}