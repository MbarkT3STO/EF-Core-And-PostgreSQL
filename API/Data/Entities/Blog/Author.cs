using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities.Blog;

public class Author
{
	public int Id { get; set; }
	public string Name { get; set; }
	
	// SocialMedia is a complex type but it will be stored as a JSON string in the database (using the HasConversion method)
	public SocialMedia? SocialMedia { get; set; }
	
	// Nicknames is an array of strings
	public string[]? Nicknames { get; set; }

	// Navigation property to represent the Posts written by this Author
	public ICollection<Post> Posts { get; set; }
}
