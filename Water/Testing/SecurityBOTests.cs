using Backend.Core.Services.Interfaces;
using Backend.Core.BusinessObjects;
using NUnit.Framework;
using System;
using Backend.Core.BusinessObjects.Interfaces;
using Backend.Core.DatabaseObjects.Interfaces;
using Moq;
using Backend.Core.EntityObjects;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Testing
{
    public class SecurityBOTests
    {
        private Mock<IDOFactory> _mockDOFactory;
        private Mock<IServicesFactory> _mockServicesFactory;
        private Mock<ISecurityDO> _mockSecurityDO;
        private Mock<IJWTService> _mockJWTService;
        private SecurityBO _securityBO;

        [SetUp]
        public void Setup()
        {
            _mockDOFactory = new Mock<IDOFactory>();
            _mockServicesFactory = new Mock<IServicesFactory>();
            _mockSecurityDO = new Mock<ISecurityDO>();
            _mockJWTService = new Mock<IJWTService>();
            _mockDOFactory.Setup(factory => factory.CreateSecurityDO()).Returns(_mockSecurityDO.Object);
            _mockServicesFactory.Setup(factory => factory.CreateJWTService()).Returns(_mockJWTService.Object);
            _securityBO = new SecurityBO(_mockDOFactory.Object, _mockServicesFactory.Object);
        }

        [Test]
        public void ValidateAuthenticationDetails_ValidDetails()
        {
            // Arrange

            string username = "testuser";
            string password = "securepassword";
            string expectedToken = "abc123";
            AuthenticationDetailsEO authDetails = new AuthenticationDetailsEO(1, username, BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12));

            _mockSecurityDO.Setup(s => s.FetchAuthenticationDetails(username))
                           .Returns(authDetails);
            _mockJWTService.Setup(j => j.GenerateJwtToken(authDetails))
                           .Returns(new JwtSecurityToken());
            _mockJWTService.Setup(j => j.SerializeJwtToken(It.IsAny<JwtSecurityToken>()))
               .Returns(expectedToken);


            // Act
            string result = _securityBO.ValidateAuthenticationDetails(username, password);

            // Assert
            Assert.AreEqual(expectedToken, result);
        }

        [Test]
        public void ValidateAuthenticationDetails_InvalidDetails()
        {
            // Arrange

            string username = "testuser";
            string password = "securepassword";
            string expectedToken = "abc123";
            AuthenticationDetailsEO authDetails = new AuthenticationDetailsEO(1, username, BCrypt.Net.BCrypt.HashPassword("blashehas", workFactor: 12));

            _mockSecurityDO.Setup(s => s.FetchAuthenticationDetails(username))
                           .Returns(authDetails);
            _mockJWTService.Setup(j => j.GenerateJwtToken(authDetails))
                           .Returns(new JwtSecurityToken());
            _mockJWTService.Setup(j => j.SerializeJwtToken(It.IsAny<JwtSecurityToken>()))
               .Returns(expectedToken);


            // Act
            string result = _securityBO.ValidateAuthenticationDetails(username, password);

            // Assert
            Assert.AreNotEqual(expectedToken, result);
        }
        [Test]
        public void ValidateAuthenticationDetails_NoUserFound()
        {
            // Arrange

            string username = "testuser";
            string password = "securepassword";
            string expectedToken = "abc123";
            AuthenticationDetailsEO authDetails = null;

            _mockSecurityDO.Setup(s => s.FetchAuthenticationDetails(username))
                           .Returns(authDetails);

            // Act
            string result = _securityBO.ValidateAuthenticationDetails(username, password);

            // Assert
            Assert.AreEqual(result, null);
        }

        [Test]
        public void AddAuthenticationDetails_UserDoesNotExist()
        {
            // Arrange
            string username = "newuser";
            string password = "newpassword";
            _mockSecurityDO.Setup(s => s.FetchAuthenticationDetails(username))
                           .Returns((AuthenticationDetailsEO)null);
            _mockSecurityDO.Setup(s => s.AddAuthenticationDetails(username, It.IsAny<string>()))
                           .Returns(true);
            // Act
            bool result = _securityBO.AddAuthenticationDetails(username, password);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddAuthenticationDetails_UserAlreadyExists()
        {
            // Arrange
            string username = "existinguser";
            string password = "password";
            AuthenticationDetailsEO existingUser = new AuthenticationDetailsEO(1, username, BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12));
            _mockSecurityDO.Setup(s => s.FetchAuthenticationDetails(username))
                           .Returns(existingUser);
            // Act
            bool result = _securityBO.AddAuthenticationDetails(username, password);
            // Assert
            Assert.IsFalse(result);
        }
    }
}