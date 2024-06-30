using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using InterRapiStudy.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterRapiStudy.Controllers
{
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

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost]
        public async Task Post([FromBody] CreateTeacherDto createTeacherDto)
        {
            await teacherService.CreateTeacher(createTeacherDto);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
