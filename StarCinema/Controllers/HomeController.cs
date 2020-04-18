using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.IndexModels;

namespace StarCinema.Controllers
{
    public class HomeController : Controller
    {
        public IMovieRepository _movieRepo;
        public ICategoryRepository _categoryRepo;

        public HomeController(IMovieRepository movieRepo, ICategoryRepository categoryRepo)
        {
            this._movieRepo = movieRepo;
            this._categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            IndexMoviesListViewModel imlvm = new IndexMoviesListViewModel(_movieRepo.AllMovies(), this._categoryRepo.AllCategories());
            return View(imlvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
