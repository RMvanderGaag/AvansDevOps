namespace AvansDevOps;

public class SprintCreated : SprintStateBase
{
    
    public SprintCreated(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint has been created.");
    }
    
    public override void StartSprint()
    {
        _sprint.ChangeState(new SprintStarted(_sprint));
    }
    
    public override void EditSprint(Sprint updatedSprint)
    {
        _sprint.Name = updatedSprint.Name;
        _sprint.StartDate = updatedSprint.StartDate;
        _sprint.EndDate = updatedSprint.EndDate;
        Console.WriteLine("Sprint has been updated.");
    }

    public override void AddBacklogItem(BacklogItem backlogItem)
    {
        backlogItem.Sprint = _sprint;
        _sprint.BacklogItems.Add(backlogItem);
        Console.WriteLine($"Backlog item has been added to the sprint.");
    }
}