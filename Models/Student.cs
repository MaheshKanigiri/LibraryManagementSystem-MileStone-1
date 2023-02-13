using System;
using System.Collections.Generic;

namespace LibraryManagementSystem_MileStone_1.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Course { get; set; }

    public virtual ICollection<Borrow> Borrows { get; } = new List<Borrow>();
}
