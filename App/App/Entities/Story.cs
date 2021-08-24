using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Story
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public StoryIntro StoryIntro { get; set; }

        public StoryPoem StoryPoem { get; set; }

        public StoryCelebrate StoryCelebrate { get; set; }

        public bool IsDelete { get; set; }
    }
}
