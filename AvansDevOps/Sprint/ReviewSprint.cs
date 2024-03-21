namespace AvansDevOps;

public class ReviewSprint : Sprint
{
    public string? Review { get; private set; }
    
    public ReviewSprint(string name, DateTime startDate, DateTime endDate, User user) : base(name, startDate, endDate, user) {}
    
    // Only a scrum master may add a review to a sprint.
    public void AddReview(string review)
    {
        if (this.CurrentState is SprintFinished)
        {
            this.Review = review;
            CloseSprint(_scrumMaster);
        } else
        {
            Console.WriteLine("You can only add a review to a finished sprint.");
        }
    }
}