using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("Stories");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(200);

            builder.Property(p => p.Avatar)
                .IsRequired(true);

            builder.Property(p => p.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(p => p.Description)
                .IsRequired(true);

            builder.Property(p => p.IsDelete)
                .HasDefaultValue(false);

            builder.HasOne(s => s.AppUser)
                .WithMany(u => u.Storys)
                .HasForeignKey(s => s.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}