using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Riok.Mapperly.Abstractions;

namespace InterRapiStudy.Mappers;

[Mapper]
public partial class TeacherMapper
{
    public partial Teacher TeacherDtoToTeacher(CreateTeacherDto teacherDto);
    public partial FindTeacherDto TeacherToTeacherDto(Teacher teacher);
}