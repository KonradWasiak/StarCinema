﻿using StarCinema.DomainModels;
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
        void AddCategory(Category category);
        Task<Category> RemoveCategory(string category);
        Task<Movie> RemoveMovie(Movie movie);
        Task<Movie> FindMovie(int id);
        Task<Movie> FindMovie(string movieTitile);
        Task<IEnumerable<Movie>> FindMoviesFromCategory(string Category);
        Task<IEnumerable<Movie>> AllMovies();
        Task<IEnumerable<Category>> AllCategories();
        Task<IEnumerable<Movie>> FindMoviesByReleaseDate(DateTime date);
        Task<Category> FindCategory(string categoryName);

    }
}
