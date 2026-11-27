using movie_AI_BE.Enums;

namespace movie_AI_BE.Entities;

public sealed class User
{
    public int Id { get; set; } 
    public Guid UserUuid { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Hashed_Password { get; set; } = string.Empty;
    public string temp_otp_Hashed { get; set; } = string.Empty;
    public RoleType Role { get; set; } = RoleType.Member;
    public StatusTypes Status { get; set; } = StatusTypes.Deactivate;
    public bool IsVerified { get; set; } = false;
    
    public DateTimeOffset? temp_otp_TimeOut { get; set; }
    public DateTimeOffset Otp_Expired_atutc { get; set; }
    public DateTimeOffset Created_atutc { get; set; }
    public DateTimeOffset Updated_atutc { get; set; }

    public ICollection<Session> Sessions { get; set; } = new List<Session>();

    public bool CanAccessSystem => Status == StatusTypes.Active && IsVerified;
}