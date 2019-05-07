using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repo;

        public MovieController(IMovieRepository repo)
        {
            this._repo = repo;
        }
        public async Task<IActionResult> Movies()
        {
            var allMovies = await this._repo.AllMovies();
            List<MovieViewModel> moviesViewModel = new List<MovieViewModel>();
            foreach (var m in allMovies)
            {
                moviesViewModel.Add(new MovieViewModel(m));
            }
            return View(moviesViewModel);
        }
        public async Task<ActionResult> AddMovie()
        {
            var categories = await this._repo.AllCategories();
            return View(new MovieViewModel(categories));
        }

        [HttpPost]
        public ActionResult AddMovie(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                this._repo.AddMovie(new Movie()
                {
                    Title = movie.Title,
                    Directory = movie.Directory,
                    Description = movie.Description,
                    Category = new Category { CategoryName = movie.Category },
                    ReleaseDate = movie.ReleaseDate
                });
                return View();
            }
            return View(movie);
        }
    }
}