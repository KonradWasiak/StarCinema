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
            this.LatestMovies = AllMoviesList.OrderByDescending(m => m.ReleaseDate)
                                             .ToList()
                                             .Take(9);

            this.ComingSoonMovies = AllMoviesList.Where(m => m.ReleaseDate > DateTime.Today).OrderBy(m => m.ReleaseDate).Take(9).ToList();

            this.MostPopularMovies = AllMoviesList.OrderByDescending(m => m.Comments.Count)
                                                  .ThenBy(m => m.Rates.Count)
                                                  .ToList()
                                                  .Take(9);

            this.Categories = AllCategoriesList.ToList()
                                               .OrderByDescending(c => c.Movies.Count)
                                               .Take(6);
        }

    }
}

