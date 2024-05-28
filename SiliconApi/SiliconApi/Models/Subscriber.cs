namespace SiliconApi.Models;

public class Subscriber
{
    public string Id { get; set; }
    public string Email { get; set; }
    public DateTime Created { get; set; }
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekinReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }
}
