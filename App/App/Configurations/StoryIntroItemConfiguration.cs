using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryIntroItemConfiguration : IEntityTypeConfiguration<StoryIntroItem>
    {
        public void Configure(EntityTypeBuilder<StoryIntroItem> builder)
        {
            builder.ToTable("StoryIntroItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired(true);

            builder.HasOne(sii => sii.StoryIntro)
                .WithMany(si => si.StoryIntroItems)
                .HasForeignKey(sii => sii.StoryIntroId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}