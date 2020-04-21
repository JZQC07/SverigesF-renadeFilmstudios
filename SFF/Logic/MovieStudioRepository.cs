using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SFF.Models;

namespace SFF.Logic
{
    public class MovieStudioRepository
    {
        readonly GlobalDbContext _context;

        public MovieStudioRepository(GlobalDbContext context)
        {
            _context = context;
        }

        public void Add(MovieStudio movie)
        {
            _context.MovieStudio.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(MovieStudio movie)
        {
            _context.MovieStudio.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(MovieStudio movie)
        {
            _context.Entry(movie).State =
               EntityState.Modified;
            _context.SaveChanges();
        }

        public MovieStudio FindById(int id)
        {
            var results =
                (from r in _context.MovieStudio where r.Id == id select r)
                .FirstOrDefault();
            return results;

        }

    }
}