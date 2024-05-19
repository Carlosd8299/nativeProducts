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
                return null;
            }
        }


        public async Task<IdentityUser> RegisterUser(string username, string password, string email, string rol)
        {
            try
            {
                var user = new IdentityUser { UserName = username, Email = email };
                var result = await _userManager.CreateAsync(user, password);

                if (result.Errors.Any())
                    throw new InfraestructureException("No fue posible guardar el usuario");

                if (result.Succeeded)
                {
                    // Añadir roles y claims aquí
                    await _userManager.AddClaimAsync(user, new Claim("UserClaim", "UserValue"));

                    // Crear roles si no existen
                    if (await _roleManager.RoleExistsAsync(rol))
                    {
                        var role = new IdentityRole(rol);
                        // Asignar rol al usuario
                        await _userManager.AddToRoleAsync(user, rol);
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new InfraestructureException("No fue posible guardar el usuario");
            }
        }
        public async Task<bool> RegisterRol(string rol)
        {
            if (!await _roleManager.RoleExistsAsync(rol))
            {
                var role = new IdentityRole(rol);
                await _roleManager.CreateAsync(role);
                return true;
            }
            return false;
        }
    }
}

