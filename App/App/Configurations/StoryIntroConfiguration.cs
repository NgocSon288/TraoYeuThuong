using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryIntroConfiguration : IEntityTypeConfiguration<StoryIntro>
    {
        public void Configure(EntityTypeBuilder<StoryIntro> builder)
        {
            builder.ToTable("StoryIntros");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Audio)
                .IsRequired(true);

            builder.Property(p => p.Background)
                .IsRequired(true);

            builder.Property(p => p.Question)
                .IsRequired(true);

            builder.HasOne(si => si.Story)
                .WithOne(s => s.StoryIntro)
                .HasForeignKey<StoryIntro>(si => si.StoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}