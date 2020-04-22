
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

        public Review(MovieStudio movieStudio, Movie movie)
        {
            this.MovieStudio = movieStudio;
            this.Movie = movie;
        }

        public Review(MovieStudio movieStudio, Movie movie, string ReviewComment) : this(movieStudio, movie)
        {
            this.ReviewComment = ReviewComment;
        }
        public Review(MovieStudio movieStudio, Movie movie, int Rating) : this(movieStudio, movie)
        {
            this.Rating = Rating;
        }
        public Review(MovieStudio movieStudio, Movie movie, string ReviewComment, int Rating) : this(movieStudio, movie)
        {
            this.ReviewComment = ReviewComment;
            this.Rating = Rating;
        }

    }
}
