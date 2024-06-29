using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? Name { get; set; }

    public int? Credits { get; set; }

    public virtual ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
}
