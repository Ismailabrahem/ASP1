using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ContactRequestFactory
{
    public static ContactRequestEntity Create(ContactRequestRegistrationForm form, int serviceId)
    {
        try
        {
            var datetime = DateTime.Now;

            return new ContactRequestEntity
            {
                Id = Guid.NewGuid().ToString(),
                FullName = form.FullName,
                Email = form.Email,
                ServiceId = serviceId,
                ContactMessage = form.ContactMessage,
                Created = datetime,
            };
        }
        catch { }
        return null!;
    }

    public static ContactRequest Create(ContactRequestEntity entity)
    {
        try
        {
            return new ContactRequest
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Service = entity.Service!.ServiceName,
                ContactMessage = entity.ContactMessage
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<ContactRequest> Create(List<ContactRequestEntity> entities)
    {
        var requests = new List<ContactRequest>();

        try
        {
            foreach (var entity in entities)
                requests.Add(Create(entity));
        }
        catch { }
        return requests;
    }
}
