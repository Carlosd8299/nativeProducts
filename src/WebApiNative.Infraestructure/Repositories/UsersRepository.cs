using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Infraestructure.Exceptions;

namespace WebApiNative.Infraestructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public Task<User> GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> LoginUser(string username, string password, string email)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return user;
            }
            else
            {
                throw new NotFoundException("Usuario no se encuentra registrado");
            }
        }


        public async Task<IdentityUser> RegisterUser(string username, string password, string email, string rol)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Errors.Any())
                throw new InfraestructureException("No fue posible guardar el usuario");

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("UserClaim", "UserValue"));

                if (await _roleManager.RoleExistsAsync(rol))
                {
                    var role = new IdentityRole(rol);
                    // Asignar rol al usuario
                    await _userManager.AddToRoleAsync(user, rol);
                }
                else
                {
                    throw new BadRequestException("El rol enviado no existe");
                }
            }
            return user;

        }
        public async Task<bool> RegisterRol(string rol)
        {
            if (!await _roleManager.RoleExistsAsync(rol))
            {
                var role = new IdentityRole(rol);
                await _roleManager.CreateAsync(role);
                return true;
            }
            throw new ConflictException("Ya existe el rol");
        }
    }
}

