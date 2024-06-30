using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(ISubjectService subjectService) : ControllerBase
{
    // GET: api/<SubjectController>
    [HttpGet]
    public Task<IEnumerable<FindSubjectDto>> Get()
    {
        return subjectService.FindAll();
    }

    // POST api/<SubjectController>
    [HttpPost]
    public async Task Post([FromBody] CreateSubjectDto subjectDto)
    {
        await subjectService.Create(subjectDto);
    }
}