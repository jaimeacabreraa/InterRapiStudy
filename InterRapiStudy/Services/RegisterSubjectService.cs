using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class RegisterSubjectService(InterRapiStudyDbContext context) : IRegisterSubjectService
{
    public async Task Create(CreateRegisterDto createRegisterDto)
    {
        if (createRegisterDto.RegisterDetail is { Count: > 3 })
        {
            throw new InvalidOperationException("Solo se puede registrar 3 materias");
        }

        if (createRegisterDto.RegisterDetail != null)
        {
            var subjects = createRegisterDto.RegisterDetail.Select(rd => rd.Subject).ToList();

            if (subjects.Distinct().Count() != subjects.Count)
            {
                throw new InvalidOperationException(
                    "No puedes registrar  2 materias iguales.");
            }
        }


        // Verificar que no haya materias con el mismo profesor
        if (createRegisterDto.RegisterDetail != null)
        {
            var teachers = createRegisterDto.RegisterDetail.Select(rd => rd.TeacherEmail).ToList();
            if (teachers.Distinct().Count() != teachers.Count)
            {
                throw new InvalidOperationException(
                    "No se pueden registrar materias con el mismo profesor en un mismo registro.");
            }
        }


        createRegisterDto.RegisterDetail?.ForEach(rd => { });

        var student = await context.Students
            .AsNoTracking()
            .SingleAsync(st => st.Email == createRegisterDto.StudentEmail);

        if (createRegisterDto.RegisterDetail != null)
        {
            var subjectNames = createRegisterDto.RegisterDetail.Select(rd => rd.Subject).ToList();
            var teacherEmails = createRegisterDto.RegisterDetail.Select(rd => rd.TeacherEmail).ToList();

            var programSubjects = await context.ProgramSubjects
                .Include(ps => ps.Subject)
                .Include(ps => ps.Teacher)
                .Where(ps => ps.ProgramId == student.ProgramId &&
                             subjectNames.Contains(ps.Subject.Name) &&
                             teacherEmails.Contains(ps.Teacher.Email))
                .ToListAsync();

            var registerSubjects = new Register
            {
                StudentId = student.StudentId,
                RegisterDetails = new List<RegisterDetail>()
            };

            foreach (var rd in createRegisterDto.RegisterDetail)
            {
                var programSubject = programSubjects
                    .FirstOrDefault(ps => ps.Subject.Name == rd.Subject && ps.Teacher.Email == rd.TeacherEmail);

                if (programSubject != null)
                {
                    var registerDetail = new RegisterDetail
                    {
                        ProgSubj = programSubject
                        // Add other properties initialization if needed
                    };

                    registerSubjects.RegisterDetails.Add(registerDetail);
                }
            }

            registerSubjects.Uid = Guid.NewGuid().ToString();

            context.Registers.Add(registerSubjects);
        }

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<FindRegisterDto?>> FindAll()
    {
        var registers = await context.Registers
            .Include(reg => reg.RegisterDetails).ThenInclude(registerDetail => registerDetail.ProgSubj)
            .ThenInclude(programSubject => programSubject.Subject).Include(register => register.RegisterDetails)
            .ThenInclude(registerDetail => registerDetail.ProgSubj)
            .ThenInclude(programSubject => programSubject.Teacher).Include(register => register.Student)
            .Include(register => register.RegisterDetails).ThenInclude(registerDetail => registerDetail.ProgSubj)
            .ThenInclude(programSubject => programSubject.Program).ToListAsync();
        return registers.Select(r =>
        {
            return new FindRegisterDto
            {
                StudentEmail = r.Student.Email,
                Uid = r.Uid,
                RegisterDetail = r.RegisterDetails.Select(rd => new FindRegisterDetailDto
                {
                    Subject = rd.ProgSubj.Subject.Name,
                    TeacherEmail = rd.ProgSubj.Teacher.Email,
                    ProgramStudy = rd.ProgSubj.Program.Name
                })
            };
        });
    }

    public async Task<IEnumerable<FindStudentSubjectDto?>> FindStudentSubject(string studentEmail)
    {
        var subjects = await context.Registers
            .Where(rg => rg.Student.Email == studentEmail) // Corregir operador de comparación
            .SelectMany(rg => rg.RegisterDetails.Select(rd => rd.ProgSubj.Subject.Name))
            .ToListAsync();

        List<FindStudentSubjectDto> studentsSubjects = [];
        foreach (var subject in subjects)
        {
            var students = await context.Registers
                .Where(rg => rg.RegisterDetails.Any(rd => rd.ProgSubj.Subject.Name == subject))
                .Select(rg => ($"{rg.Student.Names} {rg.Student.Surnames}")).ToListAsync();

            var studentSubject = new FindStudentSubjectDto
            {
                Subject = subject,
                StudentsNames = students
            };
            
            studentsSubjects.Add(studentSubject);
        }

        return studentsSubjects;
    }
}