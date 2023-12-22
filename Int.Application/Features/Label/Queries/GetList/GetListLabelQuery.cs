using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Int.Application.Features.Queries;

public class GetListLabelQuery : IRequest<GetListResponse<GetListLabelListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public string LabelUType { get; set; }

    public int Level { get; set; }

    public class GetListLabelQueryHandler : IRequestHandler<GetListLabelQuery, GetListResponse<GetListLabelListItemDto>>
    {
        private readonly ILabelRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListLabelQueryHandler(ILabelRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLabelListItemDto>> Handle(GetListLabelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Label> models = await _productRepository.GetListAsync(
                 x => x.LabelUType == request.LabelUType && x.Level == request.Level,
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize,
                 cancellationToken: cancellationToken,
                 withDeleted: true
                 );

            GetListResponse<GetListLabelListItemDto> response = _mapper.Map<GetListResponse<GetListLabelListItemDto>>(models);

            return response;
        }
    }
}
