using AutoMapper;
using Job.Hangfire.Backend.Application.Models.Request;
using Job.Hangfire.Backend.Application.Models.Response;
using Job.Hangfire.Backend.Domain.Entities;

namespace Job.Hangfire.Backend.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmailRequest, EmailEntity>();
        CreateMap<EmailEntity, EmailResponse>();

        CreateMap<EmailLogEntity, EmailLogResponse>();
    }
}
