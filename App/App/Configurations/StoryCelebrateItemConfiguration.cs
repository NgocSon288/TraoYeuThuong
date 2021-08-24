using App.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Configurations
{
    public class StoryCelebrateItemConfiguration : IEntityTypeConfiguration<StoryCelebrateItem>
    {
        public void Configure(EntityTypeBuilder<StoryCelebrateItem> builder)
        {
            builder.ToTable("StoryCelebrateItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired(true);

            builder.Property(p => p.Image)
                .IsRequired(true);

            builder.HasOne(cs => cs.StoryCelebrate)
                .WithMany(sc=>sc.StoryCelebrateItems)
                .HasForeignKey(sci => sci.StoryCelebrateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}