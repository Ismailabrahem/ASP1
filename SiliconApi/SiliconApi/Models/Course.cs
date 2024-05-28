namespace SiliconApi.Models;

public class Course
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string OriginalPrice { get; set; }
    public string DiscountPrice { get; set; }
    public int Hours { get; set; }
    public string LikesInProcent { get; set; }
    public string NumberOfLikes { get; set; }
    public bool IsDigital { get; set; }
    public bool IsBestseller { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ImageUrl { get; set; }
    public string BigImageUrl { get; set; }
}
