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
            if (movies.MaxAmount > 0)
            {
                movies.MaxAmount--;
            }

            var rentedMovie = new RentedMovies { Movie = movies };

            RentedMovies.Add(rentedMovie);
        }

    }
}