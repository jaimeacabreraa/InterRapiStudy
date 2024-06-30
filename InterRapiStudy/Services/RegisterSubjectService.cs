using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class RegisterSubjectService(InterRapiStudyDbContext context) : IRegisterSubjectService
{
    public async Task Create(CreateRegisterDto createRegisterDto)
    {
        if (createRegisterDto.RegisterDetail.Count > 3)
        {
            throw new InvalidOperationException("Solo se puede registrar 3 materias");
        }

        var subjects = createRegisterDto.RegisterDetail.Select(rd => rd.Subject).ToList();
        
        if (subjects.Distinct().Count() != subjects.Count)
        {
            throw new InvalidOperationException(
                "No puedes registrar  2 materias iguales.");
        }
        

        // Verificar que no haya materias con el mismo profesor
        var teachers = createRegisterDto.RegisterDetail.Select(rd => rd.TeacherEmail).ToList();
        if (teachers.Distinct().Count() != teachers.Count)
        {
            throw new InvalidOperationException(
                "No se pueden registrar materias con el mismo profesor en un mismo registro.");
        }


        createRegisterDto.RegisterDetail.ForEach(rd => { });

        var student = await context.Students
            .AsNoTracking()
            .SingleAsync(st => st.Email == createRegisterDto.StudentEmail);

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
        await context.SaveChangesAsync();
    }
}