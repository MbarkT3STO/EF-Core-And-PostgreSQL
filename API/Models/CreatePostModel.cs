using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models;

public class CreatePostModel
{
	public string Title { get; set; }
	public string Content { get; set; }
	public string[] Tags { get; set; }
	public int AuthorId { get; set; }
}
