using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SFF.Models;

namespace SFF.Logic
{
    class MovieRepository
    {
        readonly GlobalDbContext _context;

        public MovieRepository(GlobalDbContext context)
        {
            this._context = context;
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State =
               EntityState.Modified;
            _context.SaveChanges();
        }

        public Movie FindById(int id)
        {
            var result =
                (from n in _context.Movies where n.Id == id select n)
                .FirstOrDefault();
            return result;

        }

    }
}