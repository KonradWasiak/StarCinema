using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        IList<Movie> SearchMovies(string title);
        Movie RemoveMovie(int movieId);
        Movie FindMovie(int movieId);
        Movie FindMovie(string movieTitile);
        IList<Movie> AllMovies(string orderBy = "");
        IList<Movie> PaginatedMovies(int page, int pageSize, string orderBy);
        IList<Movie> FindMoviesByReleaseDate(DateTime date);
        void EditMovie(int movieId, Movie movie);
        int FindMovieId(Movie movie);
        int MoviesCount();
        void AddComment(int movieId, Comment comment);
    }
}
    