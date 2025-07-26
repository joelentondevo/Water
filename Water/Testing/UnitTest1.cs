using Backend.Core.Services.Interfaces;
using Backend.Core.BusinessObjects;
using NUnit.Framework;
using System;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Login_Attempt_Tests()
        {
            SecurityBO securityBO = new SecurityBO();
            string token = securityBO.LoginAttempt("testuser", "testpassword");
            Assert.Pass();
        }
    }
}