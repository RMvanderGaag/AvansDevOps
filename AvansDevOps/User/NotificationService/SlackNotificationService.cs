namespace AvansDevOps;

public class SlackNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending slack notification: {message}");
    }
}