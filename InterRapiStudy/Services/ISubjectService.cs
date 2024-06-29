using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services
{
    public interface ISubjectService
    {
        Task Create(CreateSubjectDto subjectDto);
        Task<IEnumerable<FindSubjectDto>> FindAll ();
    }
}
