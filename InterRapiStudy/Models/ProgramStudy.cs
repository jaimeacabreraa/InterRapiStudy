namespace InterRapiStudy.Models;

public class ProgramStudy
{
    public int ProgramId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}