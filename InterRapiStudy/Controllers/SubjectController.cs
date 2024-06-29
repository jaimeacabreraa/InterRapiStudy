using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(ISubjectService subjectService) : ControllerBase
    {

        private readonly ISubjectService _subjectService = subjectService;

        // GET: api/<SubjectController>
        [HttpGet]
        public Task<IEnumerable<FindSubjectDto>> Get()
        {

            return _subjectService.FindAll();
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubjectController>
        [HttpPost]
        public async Task Post([FromBody] CreateSubjectDto subjectDto)
        {
            await _subjectService.Create(subjectDto);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
