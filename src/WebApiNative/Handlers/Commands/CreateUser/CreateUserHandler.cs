using MediatR;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Domain.Repositories;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenRepository _tokenRepository;

        public CreateUserHandler(IUsersRepository usersRepository, ITokenRepository tokenRepository)
        {
            _usersRepository = usersRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = null;
            string token = "";
            var user = await _usersRepository.RegisterUser(request.UserName, request.Password, request.Correo, request.Rol);
            if (user is not null)
            {
                response = new CreateUserResponse();
                token = await _tokenRepository.GenerateToken(request.UserName, request.Password);
                response.UserName = user.UserName;
                response.Email = user.Email;
                response.Token = token;
            }
            return response;
        }
    }
}
