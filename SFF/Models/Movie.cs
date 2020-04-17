using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int MaxAmount { get; set; }

        public bool isLent { get; set; } = false;

        public int MovieStudioId { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
