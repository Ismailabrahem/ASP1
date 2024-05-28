using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CourseDetailEntity
{
    [Key]
    public int Id { get; set; }
    public string? TitleDescription { get; set; }
    public string? AuthorImgUrl { get; set; }
    public string? CourseDescription { get; set; }
    public string[]? WhatYouWillLearn { get; set; }
    public virtual List<ProgramDetailEntity>? ProgramDetails { get; set; } = new List<ProgramDetailEntity>();
}
