using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface ITeacherService
{
    Task<IEnumerable<FindTeacherDto>> GetTeachers();
    
    Task CreateTeacher(CreateTeacherDto teacherDto);
    
}