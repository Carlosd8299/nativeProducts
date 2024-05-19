using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiNative.Domain.Repositories;
using WebApiNative.Infraestructure.Exceptions;

namespace WebApiNative.Infraestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public TokenRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(string username, string password)
        {
            try
            {
                // Verificamos credenciales con Identity
                var user = await _userManager.FindByNameAsync(username);

                if (user is null || !await _userManager.CheckPasswordAsync(user, password))
                {
                    throw new NotFoundException("No se puede generar token, revise el usuario");
                }

                var roles = await _userManager.GetRolesAsync(user);

                // Generamos un token según los claims
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(720),
                    signingCredentials: credentials);

                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return jwt;
            }
            catch (Exception ex)
            {
                throw new InfraestructureException("No se pudo generar el token");
            }
        }
    }
}
