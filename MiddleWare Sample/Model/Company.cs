using System;
using System.Collections.Generic;

namespace MiddleWare_Sample.Model;

public partial class Company
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? OwnerName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
