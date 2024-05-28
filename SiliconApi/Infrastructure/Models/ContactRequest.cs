namespace Infrastructure.Models;

public class ContactRequest
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Service { get; set; } = null!;
    public string? ContactMessage { get; set; }
}
