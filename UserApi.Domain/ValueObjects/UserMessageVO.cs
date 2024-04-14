namespace UserApi.Domain.ValueObjects
{
    public class UserMessageVO
    {
        public Guid Id { get; set; }
        public DateTime? SendedAt { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? To { get; set; }
    }
}
