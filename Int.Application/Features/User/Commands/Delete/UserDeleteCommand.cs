using AutoMapper;
using Int.Identity.Service;
using MediatR;

namespace Int.Identity.Features.Commands;

public class UserDeleteCommand : IRequest<UserDeleteResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<UserDeleteCommand, UserDeleteResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UserDeleteResponse> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = _userService.GetByIdAsync(request.Id);

            await _userService.DeleteAsync(user.Result);

            UserDeleteResponse response = _mapper.Map<UserDeleteResponse>(user);

            return response;
        }
    }
}
