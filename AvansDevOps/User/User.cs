namespace AvansDevOps;

public class User : IObserver
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<INotificationService> NotificationServices { get; set; }
    
    public User(string name, string email, List<INotificationService> notificationService)
    {
        Name = name;
        Email = email;
        NotificationServices = notificationService;
    }

    public void Update(ISubject subject, string message, string name)
    {
        foreach (var notificationService in NotificationServices)
            notificationService.SendNotification($"Notify {name}: {message}");
        
    }
}