using Microsoft.AspNetCore.Identity;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Domain.Interfaces
{
    public interface IUsersRepository
    {
        public Task<IdentityUser> RegisterUser(string username, string password, string email, string rol);
        public Task<IdentityUser> LoginUser(string username, string password, string email);
        public Task<bool> RegisterRol(string rol);
        public Task<User> GetUser(string userName);
    }
}
