using System;
using System.Collections.Generic;

namespace LibraryManagementSystem_MileStone_1.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Name { get; set; }

    public int? PageCount { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Borrow> Borrows { get; } = new List<Borrow>();
}
