using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Riok.Mapperly.Abstractions;

namespace InterRapiStudy.Mappers;

[Mapper]
public partial class SubjectMapper
{
    public partial Subject SubjectDtoToSubject(CreateSubjectDto subjectDto);
    public partial FindSubjectDto SubjectToSubjectDto(Subject subject);
}