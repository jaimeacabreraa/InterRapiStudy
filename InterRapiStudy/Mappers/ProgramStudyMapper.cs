using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Riok.Mapperly.Abstractions;

namespace InterRapiStudy.Mappers;

[Mapper]
public partial class ProgramStudyMapper
{
    public partial ProgramStudy ProgramDtoToProgram(CreateProgramStudyDto programDto);

    public partial FindProgramStudyDto ProgramToProgramDto(ProgramStudy program);
}