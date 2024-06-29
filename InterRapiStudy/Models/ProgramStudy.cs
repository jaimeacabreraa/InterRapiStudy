using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class ProgramStudy
{
    public int ProgramId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
