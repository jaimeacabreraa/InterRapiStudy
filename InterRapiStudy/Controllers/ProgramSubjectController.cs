using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterRapiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramSubjectController(IProgramSubjectService _programSubjectService) : ControllerBase
    {
        // GET: api/<ProgramSubjectController>
        [HttpGet]
        public async Task<IEnumerable<FindProgramSubjectDto>> Get()
        {
            return await _programSubjectService.FindAll();
        }

        // GET api/<ProgramSubjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProgramSubjectController>
        [HttpPost]
        public async Task Post([FromBody] CreateProgramSubjectDto createProgramSubjectDto)
        {
            await _programSubjectService.Assign(createProgramSubjectDto);   
        }

        // PUT api/<ProgramSubjectController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CreateProgramSubjectDto createProgramSubjectDto)
        {
        }

        // DELETE api/<ProgramSubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
