using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Max.Controllers
{
    public class TokenHelper
    {
        SymmetricSecurityKey symmetricSecurityKey;
        IConfiguration _configuration;
        string algorithmSignature = SecurityAlgorithms.HmacSha256Signature; // TODO
        string algorithm = SecurityAlgorithms.HmacSha256; // TODO

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Secret"]));
        }

        public string CreateToken(List<Claim> claims)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimAud = new Claim("aud", _configuration["AppSettings:ValidAudience"]);
            
            if(!claims.Any(c => c.Type.Equals("aud")))
            {
                claims.Add(claimAud);
            }

            int validMinutes = int.Parse(_configuration["AppSettings:TokenValidityInMinutes"]);
            SigningCredentials signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                algorithmSignature
            );
            int tokenValidityInMinutes = int.Parse(_configuration["AppSettings:TokenValidityInMinutes"]);

            DateTime expiresAfter = DateTime.Now.AddMinutes(validMinutes);
            DateTime notBefore = DateTime.Now; // .AddMinutes(- validMinutes);
            DateTime issuedAt = new DateTime(2023, 2, 5);
            ClaimsIdentity subject = new ClaimsIdentity(
                claims, 
                "ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

           var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["AppSettings:ValidIssuer"],
                Audience = _configuration["AppSettings:ValidAudience"],               
                Subject = subject,
                NotBefore = notBefore, 
                Expires = expiresAfter,
                IssuedAt = issuedAt, 
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public Claim[]? GetClaimsFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, 
                out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || 
                !jwtSecurityToken.Header.Alg.Equals(algorithm, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal.Claims.ToArray();
        }
    }
}
