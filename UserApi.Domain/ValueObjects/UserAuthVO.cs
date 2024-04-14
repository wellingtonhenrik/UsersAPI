namespace UserApi.Domain.ValueObjects;

public class UserAuthVO
{
    public Guid? id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Roles { get; set; }
    public DateTime? SignedAt { get; set; }
}