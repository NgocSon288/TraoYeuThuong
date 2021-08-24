using App.Configurations;
using App.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());

            builder.ApplyConfiguration(new StoryConfiguration());
            builder.ApplyConfiguration(new StoryCelebrateConfiguration());
            builder.ApplyConfiguration(new StoryCelebrateItemConfiguration());
            builder.ApplyConfiguration(new StoryIntroConfiguration());
            builder.ApplyConfiguration(new StoryIntroItemConfiguration());
            builder.ApplyConfiguration(new StoryPoemConfiguration());
            builder.ApplyConfiguration(new StoryPoemItemConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryCelebrate> StoryCelebrates { get; set; }
        public DbSet<StoryCelebrateItem> StoryCelebrateItems { get; set; }
        public DbSet<StoryIntro> StoryIntros { get; set; }
        public DbSet<StoryIntroItem> StoryIntroItems { get; set; }
        public DbSet<StoryPoem> StoryPoems { get; set; }
        public DbSet<StoryPoemItem> StoryPoemItems { get; set; }
    }
}
