namespace AvansDevOps;

public class Comment
{
    private string _username;
    private string _message;
    
    public Comment(string username, string message)
    {
        _username = username;
        _message = message;
    }
    
    public string GetUsername()
    {
        return _username;
    }
    
    public string GetMessage()
    {
        return _message;
    }
}