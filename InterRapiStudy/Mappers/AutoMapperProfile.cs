using AutoMapper;
using InterRapiStudy.Dtos;
using InterRapiStudy.Models;

namespace InterRapiStudy.Mappers;

public static class AutoMapperConfig
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Program,
                    opt => opt.MapFrom(src => src.Program.Name)
                )
                .AfterMap((src, dest) =>
                {
                    // Aquí puedes agregar lo que deseas imprimir
                    Console.WriteLine($"Mapeo completado de {src.Program.Name} a {dest.Program}");
                });

            cfg.CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Program, opt => opt.Ignore());

            cfg.CreateMap<ProgramSubject, FindProgramSubjectDto>()
                .ForMember(
                    dest => dest.Subject,
                    opt => opt.MapFrom(src => src.Subject.Name)
                )
                .ForMember(
                    dest => dest.ProgramStudy,
                    opt => opt.MapFrom(src => src.Program.Name)
                )
                .ForMember(
                    dest => dest.TeacherEmail,
                    opt => opt.MapFrom(src => src.Teacher.Email)
                );
        });

        return config.CreateMapper();
    }
}