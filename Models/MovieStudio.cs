using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Movie
{
    public class MovieStudio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

    }
}