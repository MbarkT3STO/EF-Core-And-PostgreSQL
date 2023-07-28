using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities.Blog;

public class Post
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Content { get; set; } 
	public string[] Tags { get; set; }

	// Foreign key for the Author
	public int AuthorId { get; set; }
	public Author Author { get; set; }
}
