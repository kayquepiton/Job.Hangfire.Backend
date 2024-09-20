using Job.Hangfire.Backend.Application.Models.Response;

namespace Job.Hangfire.Backend.Application.Services.Interfaces;

public interface IEmailLogService
{
    Task<IEnumerable<EmailLogResponse>> GetAllLogsAsync();
    Task<EmailLogResponse> GetLogByIdAsync(Guid id);
    Task<IEnumerable<EmailLogResponse>> GetLogsByEmailIdAsync(Guid emailId);
}
