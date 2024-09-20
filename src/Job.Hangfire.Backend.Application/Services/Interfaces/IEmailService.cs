using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Models.Response;

namespace Job.Hangfire.Backend.Application.Services.Interfaces;

public interface IEmailService
{
    Task<EmailResponse> CreateAsync(EmailRequest emailRequest);
    Task<EmailResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<EmailResponse>> GetAllAsync();
    Task<EmailResponse> UpdateAsync(Guid id, EmailRequest emailRequest);
    Task DeleteByIdAsync(Guid id);
}
