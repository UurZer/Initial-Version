using AutoMapper;
using Core.Persistence.Context;
using Int.Domain.Entities;
using Int.Identity.Repository.Service;
using MediatR;

namespace Int.Application.Features.Queries;

public class GetByIdUserQuery : IRequest<GetByIdUserResponse>
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetByIdUserQueryHandler(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User users = await _userRepository.GetAsync(predicate: b => b.Id == CoreContext.Current.User.Id,
                                                                 withDeleted: true,
                                                                 cancellationToken: cancellationToken);

            GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(users);

            return response;
        }
    }
}
