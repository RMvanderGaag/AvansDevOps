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
        throw new NotImplementedException();
    }
    
    public void CancelSprint()
    {
        throw new NotImplementedException();
    }

    public void FinishSprint()
    {
        throw new NotImplementedException();
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