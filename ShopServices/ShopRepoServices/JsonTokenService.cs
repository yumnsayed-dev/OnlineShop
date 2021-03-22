using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopCore.Domain;
using ShopCore.identity;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace ShopServices.ShopRepoServices
{
    public class JsonTokenService : IJsonToken
    {
        private readonly IConfiguration _config;

        private readonly SymmetricSecurityKey _key;
        public JsonTokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }
        public string CreateToken(AppUser user)
        {
            var Claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,user.DisplayName)
            };
            var credintials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescp = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claim),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credintials,
                Issuer = _config["Token:Issuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescp);

            return tokenHandler.WriteToken(token);

        }
    }
}
