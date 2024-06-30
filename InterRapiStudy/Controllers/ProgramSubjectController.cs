using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramSubjectController(IProgramSubjectService programSubjectService) : ControllerBase
{
    // GET: api/<ProgramSubjectController>
    [HttpGet]
    public async Task<IEnumerable<FindProgramSubjectDto>> Get()
    {
        return await programSubjectService.FindAll();
    }

    // POST api/<ProgramSubjectController>
    [HttpPost]
    public async Task Post([FromBody] CreateProgramSubjectDto createProgramSubjectDto)
    {
        await programSubjectService.Assign(createProgramSubjectDto);
    }

    // Get api/<ProgramSubjectController>/5
    [HttpGet("program/{program}")]
    public async Task<IEnumerable<FindProgramSubjectDto>> GetByProgram(string program)
    {
        return await programSubjectService.FindByProgram(program);
    }
}