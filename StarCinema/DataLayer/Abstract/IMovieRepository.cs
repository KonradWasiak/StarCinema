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

        Task<Movie> RemoveMovie(Movie movie);
        Task<Movie> FindMovie(int id);
        Task<Movie> FindMovie(string movieTitile);
        Task<IEnumerable<Movie>> AllMovies();
        Task<IEnumerable<Movie>> PaginatedMovies(int page, int itemsPerPage);
        Task<IEnumerable<Movie>> FindMoviesByReleaseDate(DateTime date);
        Task EditMovie(int movieId, Movie movie);
        Task<int> FindMovieId(Movie movie);
        Task<int> MoviesCount();
        Task AddComment(int movieId, Comment comment);
    }
}
    