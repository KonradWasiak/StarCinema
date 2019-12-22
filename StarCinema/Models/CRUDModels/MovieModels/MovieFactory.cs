using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class MovieFactory
    {
        private readonly ICategoryRepository _categoryRepo;

        public MovieFactory(ICategoryRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }
        public async Task<Movie> GetMovie(MovieViewModel movie)
        {
            var movieCategory = await this._categoryRepo.FindCategory(movie.Category);

            return new Movie()
            {
                Title = movie.Title,
                Directory = movie.Directory,
                Description = movie.Description,
                Category = movieCategory,
                ReleaseDate = movie.ReleaseDate,
                TrailerUrl = movie.TrailerUrl,
                Is3D = movie.Is3D,
                DurationTime = movie.DurationTime
            };
        }
    }
}
