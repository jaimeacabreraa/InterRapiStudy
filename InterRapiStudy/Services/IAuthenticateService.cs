using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IAuthenticateService
{
    public Task<string> Login(LoginDto loginDto);
    
    public Task<string> RegisterUser(StudentDto studentDto);

}