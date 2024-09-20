using Job.Hangfire.Backend.Application.Models.Request;

namespace Job.Hangfire.Backend.Application.Services.Interfaces;

public interface IJobSchedulerService
{
    Task EnqueueEmailJobAsync(EmailRequest emailRequest);
    Task ScheduleRecurringEmailJobAsync(EmailRequest emailRequest, string cronExpression);
    Task RemoveRecurringJobAsync(string jobId);
}
