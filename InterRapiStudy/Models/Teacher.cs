using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? Names { get; set; }

    public string? Surnames { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}
