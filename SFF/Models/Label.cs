using System;
using System.Threading.Tasks;

namespace SFF.Models
{
    public class Label
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public string City { get; set; }
        public string Title { get; set; }

        public async Task<Label> GetEtikettData(GlobalDbContext _context, int movieId, int MovieStudioId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var movieStudio = await _context.MovieStudio.FindAsync(MovieStudioId);

            var label = new Label() { DateRented = DateTime.Now, Title = movie.Title, City = movieStudio.City };


            return label;
        }
        public Label CreateLabel(Label label)
        {
            return label;
        }
    }

}