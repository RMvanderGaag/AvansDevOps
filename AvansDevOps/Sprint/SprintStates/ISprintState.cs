namespace AvansDevOps;

public interface ISprintState
{
    void StartSprint();
    void CloseSprint(string review);
    void CancelSprint();
    void FinishSprint();
    void EditSprint(Sprint updatedSprint);
    void AddBacklogItem(BacklogItem backlogItem);
    void StartRelease(bool failRelease);
    void CancelRelease();
    void StartReview();
}