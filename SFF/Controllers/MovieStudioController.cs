using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF.Models;

namespace SFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStudioController : ControllerBase
    {
        private readonly GlobalDbContext _context;

        public MovieStudioController(GlobalDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieStudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStudio>>> GetMovieStudio()
        {
            return await _context.MovieStudio.ToListAsync();
        }

        // GET: api/MovieStudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieStudio>> GetMovieStudio(int id)
        {
            var movieStudio = await _context.MovieStudio.FindAsync(id);

            if (movieStudio == null)
            {
                return NotFound();
            }

            return movieStudio;
        }

        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<IEnumerable<String>>> GetMovies(int id)
        {
            var movieStudioModel = await _context.MovieStudio.Where(m => m.Id == id)
                                                              .Include(a => a.RentedMovies)
                                                              .ThenInclude(a => a.Movie)
                                                              .ToListAsync();

            if (movieStudioModel.FirstOrDefault() == null)
            {
                return NotFound();
            }
            var rentedMovies = movieStudioModel.FirstOrDefault().RentedMovies.ToList();

            var movies = rentedMovies.Select(m => m.Movie).ToList();

            List<string> movieTitles = new List<string>();
            foreach (var m in movies)
            {
                movieTitles.Add(m.Title);
            }
            return movieTitles;
        }



        // PUT: api/MovieStudio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieStudio(int id, MovieStudio movieStudio)
        {
            if (id != movieStudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieStudioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieStudio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // Create and add a studio
        [HttpPost]
        public async Task<ActionResult<MovieStudio>> PostMovieStudio(MovieStudio movieStudio)
        {
            _context.MovieStudio.Add(movieStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieStudio", new { id = movieStudio.Id }, movieStudio);
        }

        [HttpPost("AddMovieToStudio/{studioId}/{movieId}")]
        public async Task<ActionResult<Movie>> PostMovieToStudio(int studioId, int movieId)
        {
            var movieStudio = await _context.MovieStudio.Where(m => m.Id == studioId).FirstOrDefaultAsync();

            if (movieStudio != null)
            {
                var movie = await _context.Movies.Where(m => m.Id == movieId).FirstOrDefaultAsync();

                movieStudio.AddRentedMovie(movie);

                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            return StatusCode(400);

        }

        [HttpDelete("RemoveMovie/{studioId}/{movieId}")]
        public async Task<ActionResult<Movie>> RemoveMovieFromStudio(int studioId, int movieId)
        {
            var movieStudio = await _context.MovieStudio.Where(m => m.Id == studioId)
                                                             .Include(a => a.RentedMovies)
                                                             .ThenInclude(a => a.Movie)
                                                             .FirstOrDefaultAsync();

            if (movieStudio == null)
            {
                return NotFound();
            }

            var RentedMovie = movieStudio.ReturnMovie(movieId);

            _context.RentedMovies.Remove(RentedMovie);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }


        // DELETE: api/MovieStudio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieStudio>> DeleteMovieStudio(int id)
        {
            var movieStudio = await _context.MovieStudio.FindAsync(id);
            if (movieStudio == null)
            {
                return NotFound();
            }

            _context.MovieStudio.Remove(movieStudio);
            await _context.SaveChangesAsync();

            return movieStudio;
        }

        private bool MovieStudioExists(int id)
        {
            return _context.MovieStudio.Any(e => e.Id == id);
        }
    }
}
