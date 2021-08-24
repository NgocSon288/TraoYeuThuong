using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class StoryIntro
    {
        public int Id { get; set; }

        public string Background { get; set; }

        public string Audio { get; set; }

        public string Question { get; set; }

        public Guid StoryId { get; set; }

        public Story Story { get; set; }

        public List<StoryIntroItem> StoryIntroItems { get; set; }
    }
}
