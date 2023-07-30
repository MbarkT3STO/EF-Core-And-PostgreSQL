using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Entities.Blog.EntityConfigs;

public class AuthorEntityConfigs : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.ToTable("Authors");

		builder.HasKey(a => a.Id);
		builder.Property(a => a.Id).ValueGeneratedOnAdd();

		builder.HasMany(a => a.Posts).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);

		// SocialMedia conversion to JSON string and back to SocialMedia object
		builder.Property(a => a.SocialMedia)
			.HasColumnType("jsonb")
			.HasConversion(
				v => JsonSerializer.Serialize(v, new JsonSerializerOptions { PropertyNamingPolicy = null }),
				v => JsonSerializer.Deserialize<SocialMedia>(v, new JsonSerializerOptions { PropertyNamingPolicy = null })
			);
	}
}
