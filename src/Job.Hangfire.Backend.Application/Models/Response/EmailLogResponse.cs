namespace Job.Hangfire.Backend.Application.Models.Response;

public class EmailLogResponse
{
    public Guid Id { get; set; }
    public Guid EmailId { get; set; }
    public DateTime LoggedAt { get; set; }
    public string? Message { get; set; }
    public string? ErrorMessage { get; set; }
}
