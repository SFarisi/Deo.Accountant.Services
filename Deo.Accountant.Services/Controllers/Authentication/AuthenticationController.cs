
using Deo.Accountant.Services.Common;
using Deo.Accountant.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
 
using System.Text;

namespace Deo.Accountant.Services.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public readonly Deo.Provider.AllyCompany db;
        public AuthenticationController(Deo.Provider.AllyCompany data)
        {
            db = data;
        }


        [HttpPost("Login")]
        public TokenResponse Login([FromBody] Deo.Mutiyat.Model.User.User users)
        {
            if (!db.Users.Any(x => x.Name == users.Name && x.Password == users.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(DeoConfigurationManager.AppSetting["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.Name)
              }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenResponse { Token = tokenHandler.WriteToken(token) };

        }
 
    }
}
