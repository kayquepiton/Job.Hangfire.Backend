using AutoMapper;
using FluentValidation;
using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Models.Response;
using Job.Hangfire.Backend.Application.Services.Interfaces;
using Job.Hangfire.Backend.Domain.Entities;
using Job.Hangfire.Backend.Infra.Data.Repository.Interfaces;

namespace Job.Hangfire.Backend.Application.Services;

public class EmailService : IEmailService
{
    private readonly IGenericRepository<EmailEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<EmailRequest> _emailRequestValidator;

    public EmailService(IGenericRepository<EmailEntity> repository, IMapper mapper, IValidator<EmailRequest> emailRequestValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _emailRequestValidator = emailRequestValidator;
    }

    public async Task<EmailResponse> CreateAsync(EmailRequest emailRequest)
    {
        var validationResult = await _emailRequestValidator.ValidateAsync(emailRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var emailEntity = _mapper.Map<EmailEntity>(emailRequest);
        emailEntity = await _repository.CreateAsync(emailEntity);
        return _mapper.Map<EmailResponse>(emailEntity);
    }

    public async Task<EmailResponse> GetByIdAsync(Guid id)
    {
        var emailEntity = await _repository.GetByIdAsync(id);

        if (emailEntity is null)
            throw new ApplicationException($"Email with ID {id} not found.");

        return _mapper.Map<EmailResponse>(emailEntity);
    }

    public async Task<IEnumerable<EmailResponse>> GetAllAsync()
    {
        var emailEntities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmailResponse>>(emailEntities);
    }

    public async Task<EmailResponse> UpdateAsync(Guid id, EmailRequest emailRequest)
    {
        var validationResult = await _emailRequestValidator.ValidateAsync(emailRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var emailEntity = await _repository.GetByIdAsync(id);
        if (emailEntity is null)
            throw new ApplicationException($"Email with ID {id} not found.");

        _mapper.Map(emailRequest, emailEntity);
        emailEntity = await _repository.UpdateAsync(emailEntity);
        return _mapper.Map<EmailResponse>(emailEntity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var emailEntity = await _repository.GetByIdAsync(id);

        if (emailEntity is null)
            throw new ApplicationException($"Email with ID {id} not found.");

        await _repository.DeleteByIdAsync(id);
    }
}
