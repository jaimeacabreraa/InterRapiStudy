using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IProgramSubjectService
{
    public Task<IEnumerable<FindProgramSubjectDto>> FindAll();

    public Task Assign(CreateProgramSubjectDto createProgramSubject);
}