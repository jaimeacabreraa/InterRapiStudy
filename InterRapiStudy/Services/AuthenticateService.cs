using InterRapiStudy.Context;
using InterRapiStudy.Custom;
using InterRapiStudy.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class AuthenticateService(InterRapiStudyDbContext context, Utilidades utilidades) : IAuthenticateService
{
    public async Task<string> Login(LoginDto loginDto)
    {
        var student = await context.Students
            .Include(user => user.Program)
            .FirstAsync(user => user.Email == loginDto.Email);

        if (student.Password == loginDto.Password)
        {
            return utilidades.GenerateToken(student);
        }

        throw new HttpRequestException("Credenciales incorrectas");
    }

    public Task<string> RegisterUser(StudentDto studentDto)
    {
        throw new NotImplementedException();
    }
}