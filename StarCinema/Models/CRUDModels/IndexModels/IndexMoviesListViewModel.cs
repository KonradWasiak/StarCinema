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
            //this.LatestMovies = from movie in AllMoviesList
            //                    where (movie.ReleaseDate > DateTime.Today.AddMonths(-1) && movie.ReleaseDate <= DateTime.Today)
            //                    orderby movie.ReleaseDate
            //                    select movie;
            this.LatestMovies = AllMoviesList.Where(m => (m.ReleaseDate > DateTime.Today.AddMonths(-1)) && (m.ReleaseDate < DateTime.Today))
                                             .ToList().OrderByDescending(m => m.ReleaseDate);
            //this.ComingSoonMovies = from movie in AllMoviesList
            //                        where movie.ReleaseDate > DateTime.Today
            //                        select movie;
            this.ComingSoonMovies = AllMoviesList.Where(m => m.ReleaseDate > DateTime.Today).ToList().OrderBy(m => m.ReleaseDate);
            //this.MostPopularMovies = from movie in AllMoviesList
            //                         orderby movie.Rates.Count descending
            //                         select movie;
            this.MostPopularMovies = AllMoviesList.ToList().OrderByDescending(m => m.Rates.Count);

            this.Categories = AllCategoriesList.ToList().OrderByDescending(c => c.Movies.Count)
                                               .Take(6);
        }

    }
}

