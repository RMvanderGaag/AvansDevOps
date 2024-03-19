namespace AvansDevOps;

public interface ISprintState
{
    void StartSprint();
    void CloseSprint();
    void CancelSprint();
    void FinishSprint();
}