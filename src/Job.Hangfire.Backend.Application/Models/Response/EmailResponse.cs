namespace Job.Hangfire.Backend.Application.Models.Response;

public class EmailResponse
{
    public Guid Id { get; set; }
    public string? Recipient { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
    public string? ErrorMessage { get; set; }
}
