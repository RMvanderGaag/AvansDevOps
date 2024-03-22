namespace AvansDevOps;

public class Forum
{
    private List<Thread> _threads = new List<Thread>();
    
    public void AddThread(Thread thread)
    {
        if (thread.GetBacklogItem().State is not Done)
        {
            _threads.Add(thread);
        } 
        else
        {
            throw new Exception("Cannot add threads to a done backlog item.");
        }
    }
}