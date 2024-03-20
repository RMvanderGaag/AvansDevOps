namespace AvansDevOps;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public INotificationService NotificationService { get; set; }
    
    public User(string name, string email, INotificationService notificationService)
    {
        Name = name;
        Email = email;
        NotificationService = notificationService;
    }
}