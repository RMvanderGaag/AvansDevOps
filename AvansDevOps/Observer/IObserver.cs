namespace AvansDevOps;

public interface IObserver
{
    void Update(ISubject subject, string message, string name);
}