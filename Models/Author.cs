using System;
using System.Collections.Generic;

namespace LibraryManagementSystem_MileStone_1.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
