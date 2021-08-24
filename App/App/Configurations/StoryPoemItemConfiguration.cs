using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryPoemItemConfiguration : IEntityTypeConfiguration<StoryPoemItem>
    {
        public void Configure(EntityTypeBuilder<StoryPoemItem> builder)
        {
            builder.ToTable("StoryPoemItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired(true);

            builder.HasOne(spi => spi.StoryPoem)
                .WithMany(sp => sp.StoryPoemItems)
                .HasForeignKey(spi => spi.StoryPoemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}