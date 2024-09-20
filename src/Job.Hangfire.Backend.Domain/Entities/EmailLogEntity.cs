namespace Job.Hangfire.Backend.Domain.Entities;

public class EmailLogEntity : BaseEntity
{
    public Guid EmailId { get; set; }
    public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    public string Message { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }
}
