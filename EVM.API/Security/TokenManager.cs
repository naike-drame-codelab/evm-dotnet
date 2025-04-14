﻿using EVM.Application.Interfaces.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EVM.API.Security
{
    public class TokenManager(TokenManager.Config config) : ITokenManager
    {
        public class Config
        {
            public string Secret { get; set; } = null!;
            public int Duration { get; set; }
            public string Issuer { get; set; } = null!;
            public string Audience { get; set; } = null!;
        }

        public string CreateToken(int id, string email, string role)
        {
            JwtSecurityTokenHandler handler = new();
            JwtSecurityToken token = new(
                // issuer
                config.Issuer,
                // audience
                config.Audience,
                // claims
                CreateClaims(id, email, role),
                // start
                DateTime.Now,
                // expires
                DateTime.Now.AddSeconds(config.Duration),
                //  signingKey
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret)),
                    SecurityAlgorithms.HmacSha256
                ));
            return handler.WriteToken(token);
        }

        private IEnumerable<Claim> CreateClaims(int id, string email, string role)
        {
            yield return new Claim(ClaimTypes.Email, email);
            yield return new Claim(ClaimTypes.Role, role);
            yield return new Claim(ClaimTypes.NameIdentifier, id.ToString(), ClaimValueTypes.Integer32);
        }
    }
}
