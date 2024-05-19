using MediatR;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Domain.Repositories;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class CreateRolHandler : IRequestHandler<CreateRolCommand, bool>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenRepository _tokenRepository;

        public CreateRolHandler(IUsersRepository usersRepository, ITokenRepository tokenRepository)
        {
            _usersRepository = usersRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<bool> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            return await _usersRepository.RegisterRol(request.Rol);
        }
    }
}
