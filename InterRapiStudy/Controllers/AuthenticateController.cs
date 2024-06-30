using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterRapiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IAuthenticateService authenticateService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<string?> Login([FromBody] LoginDto loginDto)
        {
            return await authenticateService.Login(loginDto);
        }
    }
}
