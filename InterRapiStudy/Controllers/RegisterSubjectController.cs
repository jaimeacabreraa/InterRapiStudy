using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterSubjectController(IRegisterSubjectService registerSubjectService) : ControllerBase
{
    // GET: api/<RegisterController>
    [HttpGet]
    public async Task<IEnumerable<FindRegisterDto?>> Get()
    {
        return await registerSubjectService.FindAll();
    }

    // POST api/<RegisterController>
    [HttpPost]
    public async Task Post([FromBody] CreateRegisterDto createRegisterDto)
    {
        await registerSubjectService.Create(createRegisterDto);
    }
    
    // GET: api/<RegisterController>
    [HttpGet("student/{student}")]
    public async Task<IEnumerable<FindStudentSubjectDto?>> Get(string student)
    {
        return await registerSubjectService.FindStudentSubject(student);
    }
}