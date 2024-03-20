namespace AvansDevOps;

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}