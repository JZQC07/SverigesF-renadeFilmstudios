using System;
using System.Linq;
using System.Collections.Generic;
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
            if (movies.AmountOfMovies > 0)
            {
                movies.AmountOfMovies--;
            }

            var rentedMovie = new RentedMovies { Movie = movies };

            RentedMovies.Add(rentedMovie);
        }

        public RentedMovies ReturnMovie(int id)
        {
            var rentedMovie = RentedMovies.Where(m => m.MovieId == id).FirstOrDefault();
            var movie = RentedMovies.Select(m => m.Movie).Where(m => m.Id == id).FirstOrDefault();

            if (rentedMovie != null)
            {
                RentedMovies.Remove(rentedMovie);
                movie.AmountOfMovies++;
            }
            return rentedMovie;
        }

    }
}