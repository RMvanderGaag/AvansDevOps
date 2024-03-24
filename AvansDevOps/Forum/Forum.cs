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
            throw new Exception("Cannot add thread to forum, backlog item is done.");
        }
    }
    
    public List<Thread> GetThreads()
    {
        return _threads;
    }
}