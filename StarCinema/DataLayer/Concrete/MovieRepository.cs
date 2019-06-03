using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StarCinema.DataLayer.Abstract
{
    public class MovieRepository : IMovieRepository
    {
        private readonly StarCinemaContext context;

        public MovieRepository(StarCinemaContext context)
        {
            this.context = context;
        }

        public async Task AddComment(int movieId, Comment comment)
        {
            var movieToUpdate = await FindMovie(movieId);
            movieToUpdate.Comments.Add(comment);
            await context.SaveChangesAsync();
        }

        public void AddMovie(Movie movie)
        {
            this.context.Movies.Add(movie);
            this.context.SaveChanges();
        }

        public async Task<IEnumerable<Movie>> AllMovies()
        {
            IEnumerable<Movie> allMovies = await context.Movies.Include(m => m.Category)
                                                               .Include(m => m.Comments)
                                                               .Include(m => m.Rates)
                                                               .Include(m => m.Shows)
                                                               .ToListAsync();
            return allMovies;
        }

        public async Task EditMovie(int movieId, Movie updatedMovie)
        {
            var movie = await FindMovie(movieId);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Directory = updatedMovie.Directory;
                movie.Description = updatedMovie.Description;
                movie.Category = updatedMovie.Category;
                movie.ReleaseDate = updatedMovie.ReleaseDate;
                movie.Is3D = updatedMovie.Is3D;
                movie.TrailerUrl = updatedMovie.TrailerUrl;
                movie.DurationTime = updatedMovie.DurationTime;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<Movie> FindMovie(int id)
        {
            var movie = await context.Movies.Include(m => m.Category)
                                            .Include(m => m.Comments).ThenInclude(c => c.User)
                                            .Include(m => m.Rates)
                                            .Include(m => m.Shows)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<Movie> FindMovie(string movieTitile)
        {
            var movie = await context.Movies.Include(m => m.Category)
                                                               .Include(m => m.Comments)
                                                               .Include(m => m.Rates)
                                                               .Include(m => m.Shows)
                                                               .FirstOrDefaultAsync(m => m.Title == movieTitile);
            return movie;
        }

        public Task<int> FindMovieId(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindMoviesByReleaseDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<int> MoviesCount()
        {
            return await this.context.Movies.CountAsync();
        }

        public async Task<IEnumerable<Movie>> PaginatedMovies(int page, int itemsPerPage)
        {
            IEnumerable<Movie> movies = await context.Movies.Include(m => m.Category)
                                                               .Include(m => m.Comments)
                                                               .Include(m => m.Rates)
                                                               .Include(m => m.Shows)
                                                               .OrderByDescending(m => m.ReleaseDate)
                                                               .Skip((page - 1) * itemsPerPage)
                                                               .Take(itemsPerPage)
                                                               .ToListAsync();
            return movies;
        }

        public async Task<Movie> RemoveMovie(Movie movie)
        {
            var movieToRemove = await FindMovie(movie.Id);
            if (movieToRemove != null)
                context.Movies.Remove(movieToRemove);

            await context.SaveChangesAsync();

            return movieToRemove;
        }


    }
}