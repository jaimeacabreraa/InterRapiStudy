using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class ProgramSubject
{
    public int ProgSubjtId { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public int ProgramId { get; set; }

    public virtual ProgramStudy Program { get; set; } = null!;

    public virtual ICollection<RegisterDetail> RegisterDetails { get; set; } = new List<RegisterDetail>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
