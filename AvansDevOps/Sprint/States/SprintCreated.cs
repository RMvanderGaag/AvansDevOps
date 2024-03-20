namespace AvansDevOps;

public class SprintCreated : ISprintState
{
    private Sprint _sprint;
    
    public SprintCreated(Sprint sprint)
    {
        this._sprint = sprint;
    }
    
    public void StartSprint()
    {
        _sprint.ChangeState(new SprintStarted(_sprint));
    }

    public void CloseSprint()
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
        _sprint.BacklogItems.Add(backlogItem);
        Console.WriteLine($"Backlog item has been added to the sprint.");
    }
}