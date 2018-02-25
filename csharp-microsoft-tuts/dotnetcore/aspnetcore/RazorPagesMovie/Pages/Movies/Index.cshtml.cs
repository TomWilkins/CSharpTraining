using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public SelectList Genres;
        public string MovieGenre { get; set; }

        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            // use LINQ to get list of genres
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // This defines the query, it has not been executed yet
            var movies = from m in _context.Movie
                         select m;

            // if a search string has been provided, add a filter to the query...
            if(!String.IsNullOrEmpty(searchString)){
                // LINQ queries are not executed when they're defined OR modified like here. 
                // query execution is defered until the value is realised through iteration.
                movies = movies.Where(s => s.Title.Contains(searchString)); // Contains is converted to SQL like and ran there, not in c#
            }

            if(!String.IsNullOrEmpty(movieGenre)){
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            // Execution now happens and the result is returned async
            Movie = await movies.ToListAsync();
        }
    }
}
