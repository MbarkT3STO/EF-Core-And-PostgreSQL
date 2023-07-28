using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities.Blog;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
	AppDbContext _context;
	
	public AuthorsController(AppDbContext context)
	{
		_context = context;
	}
	
	
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var authors = await _context.Authors.ToListAsync();
		
		return Ok(authors);
	}
	
	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var author = await _context.Authors.FindAsync(id);
		
		if (author == null)
		{
			return NotFound();
		}
		
		return Ok(author);
	}

	[HttpPost]
	public async Task<IActionResult> Post(CreateAuthorModel model)
	{
		var author = new Author
		{
			Name = model.Name
		};
		
		_context.Authors.Add(author);
		await _context.SaveChangesAsync();
		
		return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
	}
}
