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

    // GET api/<ProgramController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ProgramController>
    [HttpPost]
    public async Task Post([FromBody] CreateProgramStudyDto programStudyDto)
    {
        await programService.CreateProgram(programStudyDto);
    }

    // PUT api/<ProgramController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ProgramController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}