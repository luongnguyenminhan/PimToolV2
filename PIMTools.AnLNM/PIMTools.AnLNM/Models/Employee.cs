using System;
using System.Collections.Generic;

namespace PIMTools.AnLNM.Models;

public partial class Employee
{
    public decimal Id { get; set; }

    public string Visa { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public decimal Version { get; set; }

    public string IsExist { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

}
