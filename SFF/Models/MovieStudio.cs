using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFF.Models
{
    public class MovieStudio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }


        public ICollection<RentedMovies> RentedMovies { get; set; } = new List<RentedMovies>();
        public void AddRentedMovie(Movie movies)
        {
            if (movies.MaxAmount > 0)
            {
                movies.MaxAmount--;
            }

            var rentedMovie = new RentedMovies { Movie = movies };

            RentedMovies.Add(rentedMovie);
        }

    }
}