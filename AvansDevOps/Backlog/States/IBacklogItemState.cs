namespace AvansDevOps;

public interface IBacklogItemState
{
    void AddSubtask(Subtask subtask);
    void RemoveSubtask(Subtask subtask);
    void Complete(List<Subtask> tasks);
    void Test(bool isCorrect);
    void Check(bool isCorrect);
    void TransitionToNextState();
}