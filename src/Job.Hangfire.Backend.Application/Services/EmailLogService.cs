using AutoMapper;
using Job.Hangfire.Backend.Application.Models.Response;
using Job.Hangfire.Backend.Application.Services.Interfaces;
using Job.Hangfire.Backend.Domain.Entities;
using Job.Hangfire.Backend.Infra.Data.Repository.Interfaces;

namespace Job.Hangfire.Backend.Application.Services;

public class EmailLogService : IEmailLogService
{
    private readonly IGenericRepository<EmailLogEntity> _repository;
    private readonly IMapper _mapper;

    public EmailLogService(IGenericRepository<EmailLogEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmailLogResponse>> GetAllLogsAsync()
    {
        var logEntities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmailLogResponse>>(logEntities);
    }

    public async Task<EmailLogResponse> GetLogByIdAsync(Guid id)
    {
        var logEntity = await _repository.GetByIdAsync(id);

        if (logEntity is null)
            throw new ApplicationException($"Log with ID {id} not found.");

        return _mapper.Map<EmailLogResponse>(logEntity);
    }

    public async Task<IEnumerable<EmailLogResponse>> GetLogsByEmailIdAsync(Guid emailId)
    {
        var logEntities = await _repository.GetAllAsync();
        var filteredLogs = logEntities.Where(log => log.EmailId == emailId);
        return _mapper.Map<IEnumerable<EmailLogResponse>>(filteredLogs);
    }
}
