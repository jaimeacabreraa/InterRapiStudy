using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Riok.Mapperly.Abstractions;

namespace InterRapiStudy.Mappers;

[Mapper]
public partial class StudentMapper
{
    public partial Student StudentDtoToStudent(StudentDto studentDto);
    public partial StudentDto StudentToStudentDto(Student student);

}