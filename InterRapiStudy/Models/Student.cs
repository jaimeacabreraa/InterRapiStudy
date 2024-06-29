using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Names { get; set; }

    public string? Surnames { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public int ProgramId { get; set; }

    public virtual ProgramStudy Program { get; set; } = null!;

    public virtual ICollection<Register> Registers { get; set; } = new List<Register>();
}
