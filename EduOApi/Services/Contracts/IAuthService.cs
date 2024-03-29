﻿using EduO.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EduO.Api.Services.Contracts
{
    public interface IAuthService
    {
        public SigningCredentials GetSigningCredentials();
        public Task<List<Claim>> GetClaims(User user);
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
