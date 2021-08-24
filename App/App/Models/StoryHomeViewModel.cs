using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class StoryHomeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }
    }
}
