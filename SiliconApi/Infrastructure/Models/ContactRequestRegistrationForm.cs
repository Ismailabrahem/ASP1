namespace Infrastructure.Models;

public class ContactRequestRegistrationForm
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Service { get; set; } = null!;
    public string? ContactMessage { get; set; }
}
