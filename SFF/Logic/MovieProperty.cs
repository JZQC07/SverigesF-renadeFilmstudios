using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace SFF.Logic
{
    public class MovieProperty
    {
        public int MaxAmount { get; set; }
        public bool isLent { get; set; } = false;
        public int NumCurrentlyRented { get; set; }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal Duration { get; set; }
    }
}