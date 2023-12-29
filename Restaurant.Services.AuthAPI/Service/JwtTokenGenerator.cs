﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
           _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(ApplicationsUser applicationsUser, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationsUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, applicationsUser.Id),
                   new Claim(JwtRegisteredClaimNames.Name, applicationsUser.UserName),
            };

            claimList.AddRange(roles.Select(role=>new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
            
        }

       
    }
}
