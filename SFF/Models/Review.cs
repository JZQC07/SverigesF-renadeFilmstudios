using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int StudioId { get; set; }
        public MovieStudio MovieStudio { get; set; }

        public string ReviewComment { get; set; }

        public int Rating { get; set; } // STÖRRE ÄN 0 MINDRE ÄN 6 (1-5)

        public bool CorrectRating(Review review)
        {
            if (review.Rating < 6 && review.Rating > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
