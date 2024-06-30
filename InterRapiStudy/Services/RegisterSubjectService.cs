using InterRapiStudy.Context;
using InterRapiStudy.Dtos;
using InterRapiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace InterRapiStudy.Services;

public class RegisterSubjectService(InterRapiStudyDbContext context) : IRegisterSubjectService
{
    public async Task Create(CreateRegisterDto createRegisterDto)
    {
        var student = await context.Students
            .AsNoTracking()
            .SingleAsync(st => st.Email == createRegisterDto.StudentEmail);

        var subjectNames = createRegisterDto.RegisterDetail.Select(rd => rd.Subject).ToList();
        var teacherEmails = createRegisterDto.RegisterDetail.Select(rd => rd.TeacherEmail).ToList();

        var programSubjects = await context.ProgramSubjects
            .Include(ps => ps.Subject)
            .Include(ps => ps.Teacher)
            .Where(ps => ps.Teacher.Email != null &&
                         ps.Subject.Name != null &&
                         ps.ProgramId == student.ProgramId && 
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
                    ProgSubj = programSubject,
                    // Add other properties initialization if needed
                };

                registerSubjects.RegisterDetails.Add(registerDetail);
            }
        }

        context.Registers.Add(registerSubjects);
        await context.SaveChangesAsync();
    }

}