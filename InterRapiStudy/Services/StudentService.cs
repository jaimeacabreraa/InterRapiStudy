using AutoMapper;
using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class StudentService(InterRapiStudyDbContext context) : IStudentService
{
    private readonly IMapper _mapper = AutoMapperConfig.Initialize();


    public async Task<IEnumerable<StudentDto>> GetStudents()
    {
        var students = await context.Students.Include(st=>st.Program).Select(
            st => _mapper.Map<StudentDto>(st)
        ).ToArrayAsync();
        return students;
    }

    public async Task CreateStudent(StudentDto studentDto)
    {
        var program = await context.ProgramStudies.SingleAsync(p => p.Name == studentDto.Program);
        var student = _mapper.Map<Student>(studentDto);
        student.ProgramId = program.ProgramId;
        await context.AddAsync(student);
        await context.SaveChangesAsync();
    }

    public Task UpdateStudent(int studentId, StudentDto studentDto)
    {
        throw new NotImplementedException();
    }
}