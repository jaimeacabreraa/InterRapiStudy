using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class SubjectService(InterRapiStudyDbContext context) : ISubjectService
{
    private readonly InterRapiStudyDbContext _context = context;
    private readonly SubjectMapper _mapper = new();

    public async Task Create(CreateSubjectDto subjectDto)
    {
        var subject = _mapper.SubjectDtoToSubject(subjectDto);
        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FindSubjectDto>> FindAll()
    {
        var subjects = await _context.Subjects.ToListAsync();
        return subjects.Select(sub => _mapper.SubjectToSubjectDto(sub));
    }
}