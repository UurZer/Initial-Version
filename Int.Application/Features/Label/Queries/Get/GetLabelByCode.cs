using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Int.Application.Features.Queries;

public class GetLabelById : IRequest<LabelResponse>
{
    public Guid Id { get; set; }

    public Guid ParentId { get; set; }

    public class GetLabelByIdQueryHandler : IRequestHandler<GetLabelById, LabelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILabelRepository _labelRepository;

        public GetLabelByIdQueryHandler(IMapper mapper, ILabelRepository labelRepository)
        {
            _mapper = mapper;
            _labelRepository = labelRepository;
        }

        public async Task<LabelResponse> Handle(GetLabelById request, CancellationToken cancellationToken)
        {
            Label? label = await _labelRepository.GetAsync(x => x.Id == request.Id && x.ParentLabelId == request.ParentId,
                                                           include : x => x.Include(y => y.ParentLabel),
                                                           withDeleted: true,
                                                           cancellationToken: cancellationToken);

            LabelResponse response = _mapper.Map<LabelResponse>(label);

            return response;
        }
    }
}
