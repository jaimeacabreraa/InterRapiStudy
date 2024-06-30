using AutoMapper;
using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class ProgramSubjectService(InterRapiStudyDbContext context) : IProgramSubjectService
{
    private readonly IMapper _mapper = AutoMapperConfig.Initialize();

    public async Task<IEnumerable<FindProgramSubjectDto>> FindAll()
    {
        var programs = await context.ProgramSubjects
            .Include(ps => ps.Program)
            .Include(ps => ps.Subject)
            .Include(ps => ps.Teacher).ToListAsync();
        return programs.Select(p => _mapper.Map<FindProgramSubjectDto>(p));
    }

    public async Task Assign(CreateProgramSubjectDto createProgramSubject)
    {
        var cps = createProgramSubject;

        var subjects =
            context.ProgramSubjects.Count(ps => ps.Teacher.Email == cps.TeacherEmail && ps.Subject.Name == cps.Subject);

        if (subjects>=1)
        {
            throw new InvalidOperationException("El profesor ya tiene asigando esta materia.");
        }

        var countTeacher = context.ProgramSubjects.Count(ps => ps.Teacher.Email == cps.TeacherEmail);

        if (countTeacher >= 2)
        {
            throw new InvalidOperationException("Un profesor no puede impartir más de 2 materias.");
        }

        // Iniciar las tareas por separado sin esperarlas inmediatamente
        var program = await context.ProgramStudies.FirstOrDefaultAsync(p => p.Name == cps.ProgramStudy);
        var teacher = await context.Teachers.FirstOrDefaultAsync(t => t.Email == cps.TeacherEmail);
        var subject = await context.Subjects.FirstOrDefaultAsync(s => s.Name == cps.Subject);

        
        if (program == null)
        {
            throw new InvalidOperationException("No existe el programa");
        }
        
        if (teacher == null)
        {
            throw new InvalidOperationException("No existe el profesor");
        }
        
        if (subject == null)
        {
            throw new InvalidOperationException("No existe la materia");
        }
        var programSubject = new ProgramSubject
        {
            ProgramId = program.ProgramId,
            TeacherId = teacher.TeacherId,
            SubjectId = subject.SubjectId
        };

        context.ProgramSubjects.Add(programSubject);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FindProgramSubjectDto>> FindByProgram(string program)
    {
        return await context.ProgramSubjects.Where(ps => ps.Program.Name == program).Select(ps=>new FindProgramSubjectDto
        {
            Subject = ps.Subject.Name,
            TeacherEmail = ps.Teacher.Email,
            ProgramStudy = ps.Program.Name
        }).ToListAsync();
    }
}