﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Backend.Core.Services.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.Core.Services
{
    internal class JWTService : IJWTService
    {
        public JwtSecurityToken GenerateJwtToken(AuthenticationDetailsEO authenticationDetails)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("theforceisstringwithyoumastercodastringindeed"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, authenticationDetails.Username),
        new Claim(ClaimTypes.Role, "User"),
        new Claim(ClaimTypes.NameIdentifier, authenticationDetails.UserID.ToString()),
        new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(60).ToString())
    };

            return new JwtSecurityToken(
                issuer: "Water",
                audience: "User",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials);
        }

        public string SerializeJwtToken(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken DeserializeJwtToken(string tokenString)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
        }
    }
}
