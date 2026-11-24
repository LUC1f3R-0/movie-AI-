namespace movie_AI_BE.Entities;

public sealed class Content
{
    public int Id { get; set; }
    public Guid ContentUuid { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Poster { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string YoutubeLink { get; set; } = string.Empty;
    public bool IsMembersOnly { get; set; } = false;
    
    public DateTimeOffset Created_atutc { get; set; }
    public DateTimeOffset Updated_atutc { get; set; }
}