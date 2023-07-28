using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Entities.Blog.EntityConfigs;

public class PostEntityConfigs : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.ToTable("Posts");
		
		builder.HasKey(p => p.Id);
		
		builder.Property(p => p.Id).ValueGeneratedOnAdd();
		builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
		builder.Property(p => p.Content).IsRequired().HasMaxLength(500);
		
		builder.HasOne(p => p.Author).WithMany(a => a.Posts).HasForeignKey(p => p.AuthorId);
	}
}
