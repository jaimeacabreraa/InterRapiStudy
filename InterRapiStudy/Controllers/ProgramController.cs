using InterRapiStudy.Dtos;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramController(IProgramService programService) : ControllerBase
{
    // GET: api/<ProgramController>
    [HttpGet]
    public async Task<IEnumerable<FindProgramStudyDto>> Get()
    {
        return await programService.FindPrograms();
    }
    
    // POST api/<ProgramController>
    [HttpPost]
    public async Task Post([FromBody] CreateProgramStudyDto programStudyDto)
    {
        await programService.CreateProgram(programStudyDto);
    }
}