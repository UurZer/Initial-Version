using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Int.Domain.Entities;

namespace Int.Application.Features.Profiles;

public class LabelMappingProfiles : Profile
{
    public LabelMappingProfiles()
    {
        CreateMap<Label, CreateLabelCommand>().ReverseMap();
        CreateMap<Label, CreatedLabelResponse>().ReverseMap();

        CreateMap<Label, UpdateLabelCommand>().ReverseMap();
        CreateMap<Label, UpdatedLabelResponse>().ReverseMap();

        CreateMap<Label, DeleteLabelCommand>().ReverseMap();
        CreateMap<Label, DeletedLabelResponse>().ReverseMap();
    }
}
