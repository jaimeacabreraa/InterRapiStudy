using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class StudentService(InterRapiStudyDbContext context) : IStudentService
{
    
    private readonly InterRapiStudyDbContext _context = context;
    private readonly StudentMapper _studentMapper = new();


    public async Task<IEnumerable<StudentDto>> GetStudents()
    {
        var students = await _context.Students.Select(
            st => _studentMapper.StudentToStudentDto(st)
            ).ToArrayAsync();
        return students;
    }

    public Task CreateStudent(StudentDto studentDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudent(int studentId, StudentDto studentDto)
    {
        throw new NotImplementedException();
    }
}