using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class ProjectDetail
{
    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public string? Role { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
