using System;
using System.Collections.Generic;

namespace PIMTools.AnLNM.Models;

public partial class Group
{
    public decimal Id { get; set; }

    public decimal GroupLeaderId { get; set; }

    public decimal Version { get; set; }
    public string IsExist { get; set; }

    public virtual Employee GroupLeader { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
