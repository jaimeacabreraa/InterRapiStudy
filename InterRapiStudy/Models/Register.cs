﻿using System;
using System.Collections.Generic;

namespace InterRapiStudy.Models;

public partial class Register
{
    public int RegId { get; set; }

    public string? Uid { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int SudentId { get; set; }

    public virtual ICollection<RegisterDetail> RegisterDetails { get; set; } = new List<RegisterDetail>();

    public virtual Student Sudent { get; set; } = null!;
}