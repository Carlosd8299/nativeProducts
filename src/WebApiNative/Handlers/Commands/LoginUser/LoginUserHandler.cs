using MediatR;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Domain.Repositories;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenRepository _tokenRepository;

        public LoginUserHandler(IUsersRepository usersRepository, ITokenRepository tokenRepository)
        {
            _usersRepository = usersRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            LoginUserResponse response = null;
            string token = "";
            var user = await _usersRepository.LoginUser(request.UserName, request.Password, request.Correo);
            if (user is not null)
            {
                response = new LoginUserResponse();
                token = await _tokenRepository.GenerateToken(request.UserName, request.Password);
                response.UserName = user.UserName;
                response.Email = user.Email;
                response.Token = token;
            }
            return response;
        }
    }
}
