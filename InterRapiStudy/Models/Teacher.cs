namespace InterRapiStudy.Models;

public class Teacher
{
    public int TeacherId { get; set; }

    public string Names { get; set; } = null!;

    public string Surnames { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}