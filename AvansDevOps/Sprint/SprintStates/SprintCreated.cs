namespace AvansDevOps;

public class SprintCreated : ISprintState
{
    private Sprint _sprint;
    
    public SprintCreated(Sprint sprint)
    {
        this._sprint = sprint;
        Console.WriteLine("Sprint has been created.");
    }
    
    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint while sprint is created.");
    }
    
    public void StartSprint()
    {
        _sprint.ChangeState(new SprintStarted(_sprint));
    }

    public void CloseSprint(string review)
    {
        ActionNotAllowed("close");
    }
    
    public void CancelSprint()
    {
        ActionNotAllowed("cancel");
    }

    public void FinishSprint()
    {
        ActionNotAllowed("finish");
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
        ActionNotAllowed("start release");
    }

    public void CancelRelease()
    {
        ActionNotAllowed("cancel release");
    }

    public void StartReview()
    {
        ActionNotAllowed("start review");
    }
}