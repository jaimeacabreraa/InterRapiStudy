using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using InterRapiStudy.Custom;
using InterRapiStudy.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace InterRapiStudy.Tests.Custom
{
    public class UtilidadesTests
    {
        private readonly IConfiguration _configuration;
        private readonly Utilidades _utilidades;

        public UtilidadesTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:key", "a very secure key that is at least 16 characters"},
                {"Jwt:Issuer", "yourissuer"},
                {"Jwt:Audience", "youraudience"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _utilidades = new Utilidades(_configuration);
        }

        [Fact]
        public void GenerateToken_ShouldReturnValidJwtToken()
        {
            // Arrange
            var student = new Student
            {
                Names = "John",
                Surnames = "Doe",
                Email = "john.doe@example.com",
                Program = new ProgramStudy { Name = "Computer Science" }
            };

            // Act
            var token = _utilidades.GenerateToken(student);

            // Assert
            Assert.NotNull(token);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            Assert.NotNull(jsonToken);
            Assert.Equal(_configuration["Jwt:Issuer"], jsonToken.Issuer);
            Assert.Equal(_configuration["Jwt:Audience"], jsonToken.Audiences.First());
            Assert.Equal("John", jsonToken.Claims.First(c => c.Type == ClaimTypes.Name).Value);
            Assert.Equal("Doe", jsonToken.Claims.First(c => c.Type == ClaimTypes.Surname).Value);
            Assert.Equal("john.doe@example.com", jsonToken.Claims.First(c => c.Type == ClaimTypes.Email).Value);
            Assert.Equal("Student", jsonToken.Claims.First(c => c.Type == ClaimTypes.Role).Value);
            Assert.Equal("Computer Science", jsonToken.Claims.First(c => c.Type == "Program").Value);
        }
    }
}
