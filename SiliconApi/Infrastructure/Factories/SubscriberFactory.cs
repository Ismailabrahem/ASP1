using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscriberFactory
{
    public static SubscriberEntity Create(SubscriberRegistrationForm form)
    {
        try
        {
            var dateTime = DateTime.Now;

            return new SubscriberEntity
            {
                Id = Guid.NewGuid().ToString(),
                Email = form.Email,
                DailyNewsletter = form.DailyNewsletter,
                AdvertisingUpdates = form.AdvertisingUpdates,
                WeekinReview = form.WeekinReview,
                EventUpdates = form.EventUpdates,
                StartupsWeekly = form.StartupsWeekly,
                Podcasts = form.Podcasts,
                Created = dateTime,
            };
        }
        catch { }
        return null!;
    }
}
