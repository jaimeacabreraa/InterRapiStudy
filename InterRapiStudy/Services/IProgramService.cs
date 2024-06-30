using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IProgramService
{
    public Task<IEnumerable<FindProgramStudyDto>> FindPrograms();

    public Task CreateProgram(CreateProgramStudyDto createProgramStudyDto);
}