using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController(ITeacherService teacherService) : ControllerBase
{
    // GET: api/<TeacherController>
    [HttpGet]
    public async Task<IEnumerable<FindTeacherDto>> Get()
    {
        return await teacherService.GetTeachers();
    }

    // POST api/<TeacherController>
    [HttpPost]
    public async Task Post([FromBody] CreateTeacherDto createTeacherDto)
    {
        await teacherService.CreateTeacher(createTeacherDto);
    }
}