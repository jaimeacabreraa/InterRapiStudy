namespace InterRapiStudy.Models;

public class Student
{
    public int StudentId { get; set; }

    public string Names { get; set; } = null!;

    public string Surnames { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int ProgramId { get; set; }

    public virtual ProgramStudy Program { get; set; } = null!;

    public virtual ICollection<Register> Registers { get; set; } = new List<Register>();
}