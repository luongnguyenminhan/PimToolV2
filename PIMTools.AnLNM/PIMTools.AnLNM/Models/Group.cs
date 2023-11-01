using System;
using System.Collections.Generic;

namespace PIMTools.AnLNM.Models;

public partial class Group
{
    public int Id { get; set; }

    public int GroupLeaderId { get; set; }

    public int Version { get; set; }

    public virtual Employee GroupLeader { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
