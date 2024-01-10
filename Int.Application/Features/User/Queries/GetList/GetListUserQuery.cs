using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Domain.Entities;
using Int.Identity.Repository.Service;
using MediatR;

namespace Int.Application.Features.Queries;

public class GetListUserQuery : IRequest<GetListResponse<GetListUserResponse>>
{
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, GetListResponse<GetListUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetListUserQueryHandler(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }

        public async Task<GetListResponse<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            Paginate<User> users = await _userRepository.GetListAsync();

            GetListResponse<GetListUserResponse> response = _mapper.Map<GetListResponse<GetListUserResponse>>(users);

            return response;
        }
    }
}
