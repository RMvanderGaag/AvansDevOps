namespace AvansDevOps;

public class ReviewSprint : Sprint
{
    public string? Review { get; private set; }
    
    public ReviewSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate) {}
    
    public void AddReview(string review)
    {
        if (this.CurrentState is SprintFinished)
        {
            this.Review = review;
        } else
        {
            Console.WriteLine("You can only add a review to a finished sprint.");
        }
    }
}