namespace AvansDevOps;

public class Thread
{
    private BacklogItem _backlogItem;
    private List<Comment> _comments = new List<Comment>();
    
    public Thread(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    // TODO: when comment is added, notify all project members.
    public void AddComment(Comment comment)
    {
        if (_backlogItem.State is not Done)
        {
            _comments.Add(comment);
            _backlogItem.Sprint.Notify($"New comment added to backlog item '{_backlogItem.GetName()}'!");
        }
        else
        {
            throw new Exception("Cannot add comments to a done backlog item.");
        }
    }
    
    public BacklogItem GetBacklogItem()
    {
        return _backlogItem;
    }
}