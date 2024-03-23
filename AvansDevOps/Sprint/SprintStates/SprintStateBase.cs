namespace AvansDevOps;

public abstract class SprintStateBase : ISprintState
{
    protected Sprint _sprint;
    
    public SprintStateBase(Sprint sprint)
    {
        this._sprint = sprint;
    }

    private static void ActionNotAllowed(string action)
    {
        Console.WriteLine($"Can't {action} a sprint in the current state.");
    }
    
    public virtual void StartRelease(bool failRelease) => ActionNotAllowed("start release");
    public virtual void CancelRelease() => ActionNotAllowed("cancel release");
    public virtual void StartReview() => ActionNotAllowed("start review");
    public virtual void StartSprint() => ActionNotAllowed("start sprint");
    public virtual void CloseSprint(string review) => ActionNotAllowed("close sprint");
    public virtual void CancelSprint() => ActionNotAllowed("cancel sprint");
    public virtual void FinishSprint() => ActionNotAllowed("finish sprint");
    public virtual void EditSprint(Sprint updatedSprint) => ActionNotAllowed("edit sprint");
    public virtual void AddBacklogItem(BacklogItem backlogItem) => ActionNotAllowed("add backlog item");
}