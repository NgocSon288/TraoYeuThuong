using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryCelebrateConfiguration : IEntityTypeConfiguration<StoryCelebrate>
    {
        public void Configure(EntityTypeBuilder<StoryCelebrate> builder)
        {
            builder.ToTable("StoryCelebrates");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired(true);

            builder.Property(p => p.Audio)
                .IsRequired(true);

            builder.Property(p => p.Background)
                .IsRequired(true);

            builder.HasOne(sc => sc.Story)
                .WithOne(s => s.StoryCelebrate)
                .HasForeignKey<StoryCelebrate>(sc => sc.StoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}