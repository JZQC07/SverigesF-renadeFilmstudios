namespace SFF.Models
{
    public class RentingHandler
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public MovieStudio MovieStudio { get; set; }

        public Review Review { get; set; }

    }
}