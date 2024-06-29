using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class RegisterDetail
{
    public int RegDetId { get; set; }

    public int RegiterId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int ProgSubjlId { get; set; }

    public virtual ProgramSubject ProgSubjl { get; set; } = null!;

    public virtual Register Regiter { get; set; } = null!;
}
