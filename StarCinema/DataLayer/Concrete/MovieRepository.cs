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

        public void AddComment(int movieId, Comment comment)
        {
            var movieToUpdate =  FindMovie(movieId);
            movieToUpdate.Comments.Add(comment); 
            context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            this.context.Movies.Add(movie);
            this.context.SaveChanges();
        }

        public IList<Movie> AllMovies(string orderBy)
        {
            var movies = context.Movies.Include(m => m.Category)
                .Include(m => m.Comments)
                .Include(m => m.Rates)
                .Include(m => m.Shows)
                .ToList();

            switch (orderBy)
            {
                case "TitleAsc":
                    return movies.OrderBy(x => x.Title).ToList();
                case "TitleDesc":
                    return movies.OrderByDescending(x => x.Title).ToList();
                case "ReleaseDateAsc":
                    return movies.OrderBy(x => x.ReleaseDate).ToList();
                case "ReleaseDateDesc":
                    return movies.OrderByDescending(x => x.ReleaseDate).ToList();
                case "CategoryAsc":
                    return movies.OrderBy(x => x.Category.CategoryName).ToList();
                case "CategoryDesc":
                    return movies.OrderByDescending(x => x.Category.CategoryName).ToList();
                default:
                    return movies.OrderBy(x => x.Title).ToList();
            }
        }

        public void EditMovie(int movieId, Movie updatedMovie)
        {
            var movie = FindMovie(movieId);
            if (String.IsNullOrEmpty(updatedMovie.Description))
            {
                updatedMovie.Description = movie.Description;
            }

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
            this.context.SaveChanges();
        }

        public Movie FindMovie(int id)
        {
            var movie = context.Movies.Include(m => m.Category)
                                            .Include(m => m.Comments).ThenInclude(c => c.User)
                                            .Include(m => m.Rates)
                                            .Include(m => m.Shows)
                                            .FirstOrDefault(m => m.Id == id);
            return movie;
        }

        public Movie FindMovie(string movieTitile)
        {
            var movie = context.Movies.Include(m => m.Category)
                                                               .Include(m => m.Comments)
                                                               .Include(m => m.Rates)
                                                               .Include(m => m.Shows)
                                                               .FirstOrDefault(m => m.Title == movieTitile);
            return movie;
        }

        public int FindMovieId(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IList<Movie> FindMoviesByReleaseDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public int MoviesCount()
        {
            return this.context.Movies.Count();
        }

        public IList<Movie> PaginatedMovies(int page, int pageSize, string orderBy)
        {
            return AllMovies(orderBy).Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Movie RemoveMovie(int movieId)
        {
            var movieToRemove = FindMovie(movieId);
            if (movieToRemove != null)
                context.Movies.Remove(movieToRemove);
            
            context.SaveChanges();

            return movieToRemove;
        }

        public IList<Movie> SearchMovies(string title)
        {
            return context.Movies.Where(x => x.Title.Contains(title))
                .Include(x => x.Comments)
                .Include(x => x.Category)
                .ToList();
        }
    }
}