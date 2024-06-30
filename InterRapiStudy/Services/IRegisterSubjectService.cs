using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IRegisterSubjectService
{
    public Task Create(CreateRegisterDto createRegisterDto);
    
    public Task<IEnumerable<FindRegisterDto?>> FindAll();

    public Task<IEnumerable<FindStudentSubjectDto?>> FindStudentSubject(string student);
}