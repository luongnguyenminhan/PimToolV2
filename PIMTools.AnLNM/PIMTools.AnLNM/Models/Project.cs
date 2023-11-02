using System;
using System.Collections.Generic;

namespace PIMTools.AnLNM.Models;

public partial class Project
{
    public decimal Id { get; set; }

    public decimal GroupId { get; set; }

    public decimal ProjectNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal Version { get; set; }
    public string IsExist { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
