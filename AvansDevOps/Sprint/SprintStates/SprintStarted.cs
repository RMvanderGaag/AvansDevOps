namespace AvansDevOps;

public class SprintStarted : SprintStateBase
{
    public SprintStarted(Sprint sprint) : base(sprint)
    {
        Console.WriteLine("Sprint has started.");
    }

    public override void FinishSprint()
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
}