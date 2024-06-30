using InterRapiStudy.Dtos;

namespace InterRapiStudy.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetStudents();

    Task CreateStudent(StudentDto studentDto);

    Task UpdateStudent(int studentId, StudentDto studentDto);
}