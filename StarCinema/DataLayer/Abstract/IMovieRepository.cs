using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface IMovieRepository : IRepository
    {
        void AddMovie(Movie movie);

        Task<Movie> RemoveMovie(Movie movie);
        Task<Movie> FindMovie(int id);
        Task<Movie> FindMovie(string movieTitile);
        Task<List<Movie>> AllMovies();
        Task<List<Movie>> PaginatedMovies(int page, int itemsPerPage);
        Task<List<Movie>> FindMoviesByReleaseDate(DateTime date);
        Task EditMovie(int movieId, Movie movie);
        Task<int> FindMovieId(Movie movie);
        Task<int> MoviesCount();
        Task AddComment(int movieId, Comment comment);
    }
}
    