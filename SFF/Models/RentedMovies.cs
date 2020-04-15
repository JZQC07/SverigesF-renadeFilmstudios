using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Models
{
    public class RentedMovies
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int MovieStudioId { get; set; }

    }
}
