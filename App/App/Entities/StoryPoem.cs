using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class StoryPoem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Background { get; set; }

        public string Audio { get; set; }

        public Guid StoryId { get; set; }

        public Story Story { get; set; }

        public List<StoryPoemItem> StoryPoemItems { get; set; }
    }
}
