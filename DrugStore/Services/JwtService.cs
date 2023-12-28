using DrugStore.Controllers.Models;
using DrugStore.Services.Iservices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DrugStore.Services
{
    public class JwtService : IJwt
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string GenerateToken(User user)
        {
            //Read from the appsettings.json
            var SecretKey = _configuration.GetSection("JwtOptions:SecretKey").Value;
            var Issuer = _configuration.GetSection("JwtOptions:Issuer").Value;
            var Audience = _configuration.GetSection("JwtOptions:Audience").Value;
            //Read the security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            //Pass in the key
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
            //A list of claims for the payload containing our content
            List<Claim>claims = new List<Claim>();
            claims.Add(new Claim("Roles",user.Role));
            //This claim adds the UserId to the token payload but convert to string since its Guid
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Username));
            //Token Descriptor
            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Audience = Audience,
                Issuer = Issuer,
                Expires = DateTime.Now.AddHours(1),
                //Pass the claims
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = cred


            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokendescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
