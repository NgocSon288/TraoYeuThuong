using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class StoryCelebrate
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Background { get; set; }

        public string Audio { get; set; }

        public Guid StoryId { get; set; }

        public Story Story { get; set; }

        public List<StoryCelebrateItem> StoryCelebrateItems { get; set; }
    }
}
