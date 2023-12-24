using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Int.Identity.Features.Rules;
using Int.Domain.Entities;
using Int.Identity.Service;
using MediatR;

namespace Int.Identity.Features.Commands;
public class UserLoginCommand : IRequest<UserLoginResponse>, ITransactionalRequest
{
    #region [ Model ]

    public string Email { get; set; }
    public string Password { get; set; }

    #endregion

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public UserLoginCommandHandler(IUserService userService, IAuthService authService, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _authService = authService;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UserLoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _userBusinessRules.CheckToUserForLogin(request.Email);
            await _userBusinessRules.CheckUserPasswordHash(request.Password, user);

            var result = _authService.CreateAccessToken(user);

            UserLoginResponse userLoginResponse = _mapper.Map<UserLoginResponse>(result);
            return userLoginResponse;
        }
    }
}
