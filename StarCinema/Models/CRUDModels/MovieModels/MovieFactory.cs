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
        public Movie GetMovie(AddEditMovieRequest addEditMovie)
        {
            var movieCategory = this._categoryRepo.FindCategory(addEditMovie.CategoryId);

            return new Movie()
            {
                Title = addEditMovie.Title,
                Directory = addEditMovie.Directory,
                Description = addEditMovie.Description,
                Category = movieCategory,
                ReleaseDate = addEditMovie.ReleaseDate,
                TrailerUrl = addEditMovie.TrailerUrl,
                Is3D = addEditMovie.Is3D,
                DurationTime = addEditMovie.DurationTime
            };
        }
    }
}
