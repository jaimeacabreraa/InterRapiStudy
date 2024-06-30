using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IRegisterSubjectService
{
    public Task Create(CreateRegisterDto createRegisterDto);
}