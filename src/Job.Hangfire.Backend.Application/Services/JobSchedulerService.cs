using Hangfire;
using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Services.Interfaces;

namespace Job.Hangfire.Backend.Application.Services;

public class JobSchedulerService : IJobSchedulerService
{
    public Task EnqueueEmailJobAsync(EmailRequest emailRequest)
    {
        BackgroundJob.Enqueue<IEmailService>(x => x.CreateAsync(emailRequest));
        return Task.CompletedTask;
    }

    public Task ScheduleRecurringEmailJobAsync(EmailRequest emailRequest, string cronExpression)
    {
        RecurringJob.AddOrUpdate<IEmailService>(x => x.CreateAsync(emailRequest), cronExpression);
        return Task.CompletedTask;
    }

    public Task RemoveRecurringJobAsync(string jobId)
    {
        RecurringJob.RemoveIfExists(jobId);
        return Task.CompletedTask;
    }
}
