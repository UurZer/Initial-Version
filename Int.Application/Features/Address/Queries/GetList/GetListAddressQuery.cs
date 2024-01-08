using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Context;
using Core.Persistence.Paging;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Queries;

public class GetListAddressQuery : IRequest<GetListResponse<GetListAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetListAddressQuery()
    {
        PageRequest = new PageRequest();
    }

    public Guid UserId { get; set; }
    public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, GetListResponse<GetListAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAddressListItemDto>> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
        {
            Paginate<Address> models = await _addressRepository.GetListAsync(
                 predicate: x => x.UserId == CoreContext.Current.User.Id,
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize,
                 cancellationToken: cancellationToken,
                 withDeleted: false
                 );

            GetListResponse<GetListAddressListItemDto> response = _mapper.Map<GetListResponse<GetListAddressListItemDto>>(models);

            return response;
        }
    }
}
