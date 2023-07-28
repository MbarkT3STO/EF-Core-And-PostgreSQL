using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities.Blog;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
	AppDbContext _context;
	
	public PostsController(AppDbContext context)
	{
		_context = context;
	}
	
	[HttpGet]
	public IActionResult Get()
	{
		var posts = _context.Posts.ToList();
		return Ok(posts);
	}
	
	[HttpGet("{id}")]
	public IActionResult Get(int id)
	{
		var post = _context.Posts.FirstOrDefault(p => p.Id == id);
		if (post == null)
		{
			return NotFound();
		}
		return Ok(post);
	}
	
	[HttpPost]
	public IActionResult Post([FromBody] CreatePostModel model)
	{
		var post = new Post
		{
			Title = model.Title,
			Content = model.Content,
			AuthorId = model.AuthorId,
			Tags = model.Tags
		};
		_context.Posts.Add(post);
		_context.SaveChanges();
		return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
	}
}
