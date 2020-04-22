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
    public class ReviewController : ControllerBase
    {
        private readonly GlobalDbContext _context;

        public ReviewController(GlobalDbContext context)
        {
            _context = context;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
            return await _context.Review.ToListAsync();
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Review/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Review
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        [HttpPost("PostReview/{movieId}/{studioId}")]
        public async Task<ActionResult<Review>> PostMovieTrivia(int movieId, int studioId, Review review)
        {
            var movie = await _context.Movies.Where(m => m.Id == movieId).FirstOrDefaultAsync();
            var movieStudio = await _context.MovieStudio.Where(m => m.Id == studioId).FirstOrDefaultAsync();
            if (movie != null && movieStudio != null)
            {
                if (review.CorrectRating(review))
                {
                    return StatusCode(400);
                }
                movie.AddReview(review, movieStudio);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return StatusCode(400);
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
