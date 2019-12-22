using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.IndexModels
{
    public class IndexMoviesListViewModel
    {
        public IEnumerable<Movie> LatestMovies { get; set; }
        public IEnumerable<Movie> ComingSoonMovies { get; set; }
        public IEnumerable<Movie> MostPopularMovies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IndexMoviesListViewModel(IEnumerable<Movie> AllMoviesList, IEnumerable<Category> AllCategoriesList)
        {
            this.LatestMovies = AllMoviesList.Where(m => (m.ReleaseDate > DateTime.Today.AddMonths(-12)) && (m.ReleaseDate < DateTime.Today))
                                             .ToList()
                                             .OrderByDescending(m => m.ReleaseDate)
                                             .Take(9);

            this.ComingSoonMovies = AllMoviesList.Where(m => m.ReleaseDate > DateTime.Today).ToList().OrderBy(m => m.ReleaseDate).Take(9);

            this.MostPopularMovies = AllMoviesList.ToList()
                                                  .OrderByDescending(m => m.Rates.Count)
                                                  .Take(9);

            this.Categories = AllCategoriesList.ToList()
                                               .OrderByDescending(c => c.Movies.Count)
                                               .Take(6);
        }

    }
}

