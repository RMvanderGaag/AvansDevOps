namespace AvansDevOps;

public interface ISprintState
{
    void StartSprint();
    void CloseSprint();
    void CancelSprint();
    void FinishSprint();
    void EditSprint(Sprint updatedSprint);
    void AddBacklogItem(BacklogItem backlogItem);
    void StartRelease();
    void CancelRelease();
}