using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class TeacherService(InterRapiStudyDbContext context) : ITeacherService
{
    private readonly InterRapiStudyDbContext _context = context;
    private readonly TeacherMapper _mapper = new();

    public async Task<IEnumerable<FindTeacherDto>> GetTeachers()
    {
        var teachers = await _context.Teachers.ToListAsync();
        return teachers.Select(teacher => _mapper.TeacherToTeacherDto(teacher));
    }

    public async Task CreateTeacher(CreateTeacherDto teacherDto)
    {
        var teacher = _mapper.TeacherDtoToTeacher(teacherDto);
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
    }
}