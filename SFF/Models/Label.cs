using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Models
{
    public class Label
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public string City { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
    //XML 
}