using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
             var movies = from m in _context.Movie
                 select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
            //Movie = await _context.Movie.ToListAsync();
        }
    }
}
