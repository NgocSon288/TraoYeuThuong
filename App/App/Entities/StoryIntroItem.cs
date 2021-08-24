using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class StoryIntroItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int StoryIntroId { get; set; }

        public StoryIntro StoryIntro { get; set; }
    }
}
