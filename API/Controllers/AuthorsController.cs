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
public class AuthorsController: ControllerBase
{
	AppDbContext _context;

	public AuthorsController(AppDbContext context)
	{
		_context = context;
	}


	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var authors = await _context.Authors.Select(a => new
		{
			a.Id,
			a.Name,
			SocialMedia = new
			{
				a.SocialMedia.Facebook,
				a.SocialMedia.Twitter,
				a.SocialMedia.Instagram,
				a.SocialMedia.LinkedIn
			},
			Nicknames = string.Join(", ", a.Nicknames)
		}).ToListAsync();

		return Ok(authors);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var author = await _context.Authors.Select(a => new
		{
			a.Id,
			a.Name,
			SocialMedia = new
			{
				a.SocialMedia.Facebook,
				a.SocialMedia.Twitter,
				a.SocialMedia.Instagram,
				a.SocialMedia.LinkedIn
			},
			Nicknames = string.Join(", ", a.Nicknames)
		}).FirstOrDefaultAsync(a => a.Id == id);

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
			Name = model.Name,
			SocialMedia = new SocialMedia
			{
				Facebook = model.Facebook,
				Twitter = model.Twitter,
				Instagram = model.Instagram,
				LinkedIn = model.LinkedIn
			},
			Nicknames = model.Nicknames
		};

		_context.Authors.Add(author);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
	}


	[HttpGet("[action]/{value}")]
	public async Task<IActionResult> SearchByNickNames(string value)
	{
		var authors = _context.Authors.AsEnumerable()
			.Where(a => a.Nicknames.Any(nick => nick.StartsWith(value)))
			.Select(a => new
			{
				a.Id,
				a.Name,
				SocialMedia = new
				{
					a.SocialMedia.Facebook,
					a.SocialMedia.Twitter,
					a.SocialMedia.Instagram,
					a.SocialMedia.LinkedIn
				},
				Nicknames = string.Join(", ", a.Nicknames)
			})
			.ToList();

		return Ok(authors);
	}

}
