using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<IdentityUser<int>> _userManager;

        public TokenService(
            IConfiguration config,
            UserManager<IdentityUser<int>> userManager)
        {
            string? tokenKey = config["TokenKey"];
            if (tokenKey == null)
            {
                throw new ArgumentNullException(nameof(tokenKey));
            }
            _key
                = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            _userManager = userManager;
        }

        public async Task<string> CreateToken(IdentityUser<int> user)
        {
            if (user.UserName == null)
            {
                throw new Exception("ERROR CreateToken: User name is null");
            }
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            IList<string> roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(
                roles.Select(role => new Claim(ClaimTypes.Role, role)));
            SigningCredentials creds
                = new(
                    _key,
                    SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
