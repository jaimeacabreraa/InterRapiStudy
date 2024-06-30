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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProgramSubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProgramSubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
