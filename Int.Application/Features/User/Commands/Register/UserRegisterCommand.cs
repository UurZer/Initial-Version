using AutoMapper;
using Int.Identity.Features.Rules;
using Int.Domain.Entities;
using Int.Identity.Service;
using Int.Utilities.Security.Hashing;
using MediatR;
using Int.Utility.Security.JWT;

namespace Int.Identity.Features.Commands;

public class UserRegisterCommand : IRequest<UserRegisterResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserRegisterResponse>
    {
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UserRegisterCommandHandler(IUserService userService, UserBusinessRules userBusinessRules, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<UserRegisterResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.CheckToUserForRegister(request.Email);

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = $"{request.FirstName} {request.LastName}",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            await _userService.AddAsync(user);

            AccessToken result = _authService.CreateAccessToken(user);

            UserRegisterResponse response = _mapper.Map<UserRegisterResponse>(result);
            return response;
        }
    }
}
