using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities.Blog;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation property to represent the Posts written by this Author
    public ICollection<Post> Posts { get; set; }
}
