namespace SFF.Logic
{
    public class MovieLogic : IProperty
    {
        public MovieProperty MovieProperty { get; set; }
        public MovieLogic(string Title, decimal _duration)
        {
            MovieProperty = new MovieProperty
            {
                Title = Title,
                Duration = _duration,

                // Standard max number of movies available for rent = 10
                MaxAmount = 10
            };
        }
        public MovieLogic(string Title, decimal Duration, int MaxSimultaneouslyRented) : this(Title, Duration)
        {
            MovieProperty.MaxAmount = MaxSimultaneouslyRented;
        }
        public void RentMovie(int numberOfMovies)
        {
            if (IsMaxRented(numberOfMovies))
            {
                MovieProperty.NumCurrentlyRented = numberOfMovies;
            }
            else
            {
                var exceptionString = "Maximum number of rented movies reached!";
                throw new AboveMaxRentCap(exceptionString);
            }
        }
        private bool IsMaxRented(int numberOfRentedMovies) => MovieProperty.NumCurrentlyRented + numberOfRentedMovies <= MovieProperty.MaxAmount;
    }



}