using System.IdentityModel.Tokens.Jwt;
 using System.Security.Claims;
 using System.Text;
 using InterRapiStudy.Models;
 using Microsoft.IdentityModel.Tokens;
 
 namespace InterRapiStudy.Custom;
 
 public class Utilidades(IConfiguration configuration)
 {
 
     public string GenerateToken(Student student)
     {
         var userClaims = new[]
         {
             new Claim("Names", student.Names),
             new Claim("Surname", student.Surnames),
             new Claim("Email", student.Email),
             new Claim("Role", "Student"),
             new Claim("Program", student.Program.Name)
         };
 
         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]!));
 
         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
 
         var token = new JwtSecurityToken(
             //issuer: configuration["Jwt:Issuer"],
             //audience: configuration["Jwt:Audience"],
             claims: userClaims,
             expires: DateTime.UtcNow.AddDays(1),
             signingCredentials: credentials
         );
         
         return new JwtSecurityTokenHandler().WriteToken(token);
     }
 }