using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryPoemConfiguration : IEntityTypeConfiguration<StoryPoem>
    {
        public void Configure(EntityTypeBuilder<StoryPoem> builder)
        {
            builder.ToTable("StoryPoems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired(true);

            builder.Property(p => p.Author)
                .IsRequired(true);

            builder.Property(p => p.Audio)
                .IsRequired(true);

            builder.Property(p => p.Background)
                .IsRequired(true);

            builder.HasOne(sp => sp.Story)
                .WithOne(s => s.StoryPoem)
                .HasForeignKey<StoryPoem>(sp => sp.StoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}