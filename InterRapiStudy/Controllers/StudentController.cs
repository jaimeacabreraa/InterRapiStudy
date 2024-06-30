using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/<StudentController>
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<StudentDto>> Get()
    {
        return await _studentService.GetStudents();
    }

    // POST api/<StudentController>
    [HttpPost]
    public async Task Post([FromBody] StudentDto studentDto)
    {
        await _studentService.CreateStudent(studentDto);
    }
}