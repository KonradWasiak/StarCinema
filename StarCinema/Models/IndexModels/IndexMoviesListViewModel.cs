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
        public IEnumerable<Movie> HighestRateMovies { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    public IndexMoviesListViewModel(IEnumerable<Movie> AllMoviesList, IEnumerable<Category> AllCategoriesList)
        {
            this.LatestMovies = from movie in AllMoviesList
                                where movie.ReleaseDate > DateTime.Today.AddMonths(-1)
                                orderby movie.ReleaseDate
                                select movie;

            this.ComingSoonMovies = from movie in AllMoviesList
                                    where movie.ReleaseDate > DateTime.Today
                                    select movie;

            this.Categories = AllCategoriesList.OrderByDescending(c => c.Movies.Count).Take(6);
        }

    }
}

