using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Entities
{
    public class StoryCelebrateItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int StoryCelebrateId { get; set; }

        public StoryCelebrate StoryCelebrate { get; set; }
    }
}
