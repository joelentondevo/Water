using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using BCrypt.Net;
using Backend.Core.DatabaseObjects;
using System.IdentityModel.Tokens.Jwt;
using Backend.Core.Services;
using Backend.Core.Services.Interfaces;
using Backend.Core.BusinessObjects.Interfaces;

namespace Backend.Core.BusinessObjects
{
    public class SecurityBO : ISecurityBO 
    {
        IDOFactory _dOFactory;
        ISecurityDO _securityDO;
        IServicesFactory _servicesFactory;
        IJWTService _jwtService;

        public SecurityBO(IDOFactory dOFactory, IServicesFactory servicesFactory)
        {
            _dOFactory = dOFactory;
            _servicesFactory = servicesFactory;
            _securityDO = _dOFactory.CreateSecurityDO();
            _jwtService =  _servicesFactory.CreateJWTService();
        }

        public string ValidateAuthenticationDetails(string inputUsername, string inputPassword)
        {
            var retrievedAuthenticationDetails = _securityDO.FetchAuthenticationDetails(inputUsername);
            if (retrievedAuthenticationDetails == null)
            {
                return null; // User not found
            }
            else
            {
                if(BCrypt.Net.BCrypt.Verify(inputPassword, retrievedAuthenticationDetails.Password))
                {
                    JwtSecurityToken jwtToken = _jwtService.GenerateJwtToken(retrievedAuthenticationDetails);
                    string tokenString = _jwtService.SerializeJwtToken(jwtToken);
                    return tokenString;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool AddAuthenticationDetails(string inputUsername, string inputPassword)
        {
            if (_securityDO.FetchAuthenticationDetails(inputUsername) != null)
            {
                return false; // User already exists
            }
            else
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(inputPassword, workFactor: 12);
                return _securityDO.AddAuthenticationDetails(inputUsername, hashedPassword);
            }
            
        }
    }
}
