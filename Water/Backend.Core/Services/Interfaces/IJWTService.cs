using Backend.Core.EntityObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Services.Interfaces
{
    public interface IJWTService
    {
        JwtSecurityToken GenerateJwtToken(AuthenticationDetailsEO authenticationDetails);

        string SerializeJwtToken(JwtSecurityToken token);

        JwtSecurityToken DeserializeJwtToken(string tokenString);
    }
}
