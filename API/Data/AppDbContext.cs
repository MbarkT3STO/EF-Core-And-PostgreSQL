using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Data.Entities.Blog;
using API.Data.Entities.Sales;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
		
		base.OnModelCreating(modelBuilder);
	}

	// sales
	public DbSet<Order> Orders { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Product> Products { get; set; }
	
	// blog
	public DbSet<Author> Authors { get; set; }
	public DbSet<Post> Posts { get; set; }
}
