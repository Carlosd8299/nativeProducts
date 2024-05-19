using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Web.Helpers;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Infraestructure.DataAccess.Seeds
{
    public class AuthSeed : IEntityTypeConfiguration<User>
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthSeed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Insertar registros iniciales
            builder.HasData(
                new User
                {
                    FirstName = "Carlos",
                    LastName = "De la cruz",
                    PasswordHash = Crypto.HashPassword("CarlosDlc"),
                    Email = "carlosd8299@hotmail.com"
                }
            );
        }

        public async void other()
        {
            if (!_userManager.Users.Any())
            {
                var newUser = new User
                {
                    Email = "test@demo.com",
                    FirstName = "Test",
                    LastName = "User",
                    UserName = "test.demo"
                };

                await _userManager.CreateAsync(newUser, "P@ss.W0rd");
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "AnotherRole"
                });

                await _userManager.AddToRoleAsync(newUser, "Admin");
                await _userManager.AddToRoleAsync(newUser, "AnotherRole");
            }
        }
    }
}
