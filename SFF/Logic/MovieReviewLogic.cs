using SFF.Models;
namespace SFF.Logic
{
    public class MovieReviewLogic
    {
        public MovieStudio MovieStudio { get; set; }
        public MovieLogic Movie { get; set; }
        public string ReviewComment { get; set; }
        public int Rating { get; set; }

        private MovieReviewLogic(MovieStudio movieStudio, MovieLogic movie)
        {
            this.MovieStudio = movieStudio;
            this.Movie = movie;
        }
        public MovieReviewLogic(MovieStudio movieStudio, MovieLogic movie, string ReviewComment) : this(movieStudio, movie)
        {
            this.ReviewComment = ReviewComment;
        }
        public MovieReviewLogic(MovieStudio movieStudio, MovieLogic movie, int Rating) : this(movieStudio, movie)
        {
            this.Rating = Rating;
        }
        public MovieReviewLogic(MovieStudio movieStudio, MovieLogic movie, int Rating, string ReviewComment) : this(movieStudio, movie)
        {
            this.Rating = Rating;
            this.ReviewComment = ReviewComment;
        }
    }
}