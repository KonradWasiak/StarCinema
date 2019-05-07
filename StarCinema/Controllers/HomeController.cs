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
        public IMovieRepository _repo { get; }

        public HomeController(IMovieRepository repo)
        {
            this._repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            IndexMoviesListViewModel imlvm = new IndexMoviesListViewModel(await this._repo.AllMovies(), await this._repo.AllCategories());
            return View(imlvm);
        }

        public async Task<IActionResult> AddDataAsync()
        {
            var categories = new List<Category>
            {
                new Category { CategoryName = "Action"},
                new Category { CategoryName = "Sci-Fi"},
                new Category { CategoryName = "Thriller"},
                new Category { CategoryName = "Horror"},
                new Category { CategoryName = "Comedy"},
                new Category { CategoryName = "Cartoon"},
            };
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var movies = new List<Movie>
            {
                new Movie { Title = "Interstellar", Category = categories.ElementAt(0), Description = loremIpsum, ReleaseDate = DateTime.Today.AddMonths(-2)},
                new Movie { Title = "After", Category = categories.ElementAt(4), Description = loremIpsum, ReleaseDate = DateTime.Today, },
                new Movie { Title = "Belzebub", Category = categories.ElementAt(1), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(-12)},
                new Movie { Title = "Hellboy", Category = categories.ElementAt(4), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(-25), },
                new Movie { Title = "Impostor", Category = categories.ElementAt(5), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(-17)},
                new Movie { Title = "Vox Lux", Category = categories.ElementAt(3), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(11), },
                new Movie { Title = "Dumbo", Category = categories.ElementAt(1), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(5), },
                new Movie { Title = "The Tomorrow Man", Category = categories.ElementAt(0), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(15), },
                new Movie { Title = "General Commander", Category = categories.ElementAt(1), Description = loremIpsum, ReleaseDate = DateTime.Today.AddDays(22), },

            };



            foreach (var x in categories)
            {
                this._repo.AddCategory(x);
            }
            foreach (var x in movies)
            {
                this._repo.AddMovie(x);
            }

            IndexMoviesListViewModel imlvm = null;
            return View(imlvm);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
