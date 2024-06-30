using AutoMapper;
using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class ProgramSubjectService(InterRapiStudyDbContext context):IProgramSubjectService
{
    
    private readonly IMapper _mapper = AutoMapperConfig.Initialize();
    
    public async Task<IEnumerable<FindProgramSubjectDto>> FindAll()
    {
        var programs = await context.ProgramSubjects
            .Include(ps => ps.Program)
            .Include(ps=>ps.Subject)
            .Include(ps=>ps.Teacher).ToListAsync();
        return programs.Select(p => _mapper.Map<FindProgramSubjectDto>(p));
    }

    public async Task Assign(CreateProgramSubjectDto createProgramSubject)
    {
        var cps = createProgramSubject;
    
        // Iniciar las tareas por separado sin esperarlas inmediatamente
        var program =await context.ProgramStudies.SingleAsync(p => p.Name == cps.ProgramStudy);
        var teacher =await context.Teachers.SingleAsync(t => t.Email == cps.TeacherEmail);
        var subject =await context.Subjects.SingleAsync(s => s.Name == cps.Subject);


        var programSubject = new ProgramSubject
        {
            ProgramId = program.ProgramId,
            TeacherId = teacher.TeacherId,
            SubjectId = subject.SubjectId,
        };

        context.ProgramSubjects.Add(programSubject);

        await context.SaveChangesAsync();
    }
}