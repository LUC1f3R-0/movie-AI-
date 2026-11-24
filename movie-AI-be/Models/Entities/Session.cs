namespace movie_AI_BE.Entities;

public sealed class Session
{
    public int Id { get; set; }
    public Guid SessionUuid { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string RefreshToken_Hashed { get; set; } = null!;
    public string Ip_address { get; set; } = string.Empty;
    public string Device_id { get; set; } = string.Empty;
    public string Device_name { get; set; } = string.Empty;

    public DateTimeOffset Expired_atutc { get; set; }
    public DateTimeOffset Created_atutc { get; set; }
    public DateTimeOffset Updated_atutc { get; set; }
}