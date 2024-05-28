using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ProgramDetailEntity
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
}
