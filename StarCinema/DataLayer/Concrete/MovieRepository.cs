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

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            this.context.Movies.Add(movie);
            this.context.SaveChanges();
        }

        public async Task<IEnumerable<Category>> AllCategories()
        {
            IEnumerable<Category> allCategories = await context.Categories.Include(m => m.Movies).ToListAsync();
            return allCategories;
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

        public async Task<Category> FindCategory(string categoryName)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            return category;
        }

        public async Task<Movie> FindMovie(int id)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<Movie> FindMovie(string movieTitile)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Title == movieTitile);
            return movie;
        }

        public Task<IEnumerable<Movie>> FindMoviesByReleaseDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> FindMoviesFromCategory(string category)
        {
            var cat = await FindCategory(category);
            IEnumerable<Movie> allMovies = await context.Movies.ToListAsync();
            IEnumerable<Movie> moviesToReturn = from m in allMovies
                                                where m.Category == cat
                                                select m;
            return moviesToReturn;
        }

        public async Task<Category> RemoveCategory(string category)
        {
            var categoryToRemove = await FindCategory(category);
            if (categoryToRemove != null)
                context.Categories.Remove(categoryToRemove);

            await context.SaveChangesAsync();

            return categoryToRemove;
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