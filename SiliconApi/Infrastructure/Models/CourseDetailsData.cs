namespace Infrastructure.Models;

public class CourseDetailsData
{
    public class CourseDetails
    {
        public string? TitleDescription { get; set; }
        public string? AuthorImgUrl { get; set; }
        public string? CourseDescription { get; set; }
        public string[]? WhatYouWillLearn { get; set; }
        public ProgramDetail[]? ProgramDetails { get; set; }
    }
    public class ProgramDetail
    {
        public int Number { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
    }
}
