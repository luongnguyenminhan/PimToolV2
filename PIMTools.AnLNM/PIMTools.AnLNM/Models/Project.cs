using System;
using System.Collections.Generic;

namespace PIMTools.AnLNM.Models;

public partial class Project
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int ProjectNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int Version { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
