namespace InterRapiStudy.Models;

public class Subject
{
    public int SubjectId { get; set; }

    public string Name { get; set; } = null!;

    public int Credits { get; set; }

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}