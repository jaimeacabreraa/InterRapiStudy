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

    public Task Assign(CreateProgramSubjectDto createProgramSubject)
    {
        throw new NotImplementedException();
    }
}