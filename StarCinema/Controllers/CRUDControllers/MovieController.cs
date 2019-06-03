using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;
using StarCinema.Models.CRUDModels.IndexModels;
using StarCinema.Models.IndexModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IUserRepository _usrRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IRateRepository _rateRepo;

        public MovieController(IMovieRepository movieRepo, IUserRepository usrRepo, ICategoryRepository categoryRepo, IRateRepository rateRepo)
        {
            this._movieRepo = movieRepo;
            this._usrRepo = usrRepo;
            this._categoryRepo = categoryRepo;
            this._rateRepo = rateRepo;
        }
        public async Task<IActionResult> Movies(int id)
        {
            var movies = await this._movieRepo.PaginatedMovies(id, 2);
            List<MovieViewModel> moviesViewModel = new List<MovieViewModel>();
            foreach (var m in movies)
            {
                moviesViewModel.Add(new MovieViewModel(m));
            }
            int moviesCount = await this._movieRepo.MoviesCount();
            int totalPages = moviesCount % 2 > 0 ? moviesCount / 2 + 1 : moviesCount / 2;
            var paginatedMovies = new PaginatedMoviesViewModel(moviesViewModel, new PagingInfo
            {
                CurrentPage = id,
                ItemsPerPage = 2,
                TotalPages = totalPages
            });
            return View(paginatedMovies);
        }

        [HttpGet]
        public async Task<IActionResult> MoviesFromCategory(string categoryName)
        {
            var movies = await this._categoryRepo.FindMoviesFromCategory(categoryName);

            var moviesViewModel = new MoviesFromCategoryViewModel()
            {
                CategoryName = categoryName,
                MoviesFromCategory = movies
            };

            return View(moviesViewModel);
        }
        public async Task<IActionResult> ShowMovie(string id)
        {
            var movie = await this._movieRepo.FindMovie(Int32.Parse(id));
            var movieViewModel = new MovieViewModel(movie);

            movieViewModel.CanRate = TempData["RateErrorData"] == null ? true : false;

            TempData["RateErrorData"] = null;
            return View(movieViewModel);
        }

        public async Task<ActionResult> AddMovie()
        {
            var categories = await this._categoryRepo.AllCategories();
            return View(new MovieViewModel(categories));
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var movieCategory = await this._categoryRepo.FindCategory(movie.Category);
                var movieToAdd = new Movie()
                {
                    Title = movie.Title,
                    Directory = movie.Directory,
                    Description = movie.Description,
                    Category = movieCategory,
                    ReleaseDate = movie.ReleaseDate
                };

                this._movieRepo.AddMovie(movieToAdd);
                int id = movieToAdd.Id;
                var filePoster = movie.PosterImage;
                var fileBanner = movie.BannerImage;

                await ImagesUploader.UploadPoster(filePoster, id, true);
                await ImagesUploader.UploadBanner(fileBanner, id, true);
                var categories = await this._categoryRepo.AllCategories();
                return View(new MovieViewModel(categories));
            }
            return View(movie);
        }


        [HttpPost]
        public async Task<ActionResult> RemoveMovie(int movieId)
        {
            var movieToDelete = await this._movieRepo.FindMovie(movieId);
            await this._movieRepo.RemoveMovie(movieToDelete);
            return View(movieToDelete);
        }

        [HttpGet]
        public async Task<ActionResult> EditMovie(int movieId)
        {
            var movieToEdit = await this._movieRepo.FindMovie(movieId);
            var categories = await this._categoryRepo.AllCategories();

            return View(new MovieViewModel(categories, movieToEdit));
        }

        [HttpPost]
        public async Task<RedirectToActionResult> EditMovie(MovieViewModel movie)
        {
            var movieCategory = await this._categoryRepo.FindCategory(movie.Category);
            var movietoEdit = new Movie()
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

            await this._movieRepo.EditMovie(movie.Id, movietoEdit);

            int id = movie.Id;
            var filePoster = movie.PosterImage;
            var fileBanner = movie.BannerImage;

            await ImagesUploader.UploadPoster(filePoster, id, false);
            await ImagesUploader.UploadBanner(fileBanner, id, false);
            return RedirectToAction("Movies");
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectToActionResult> AddComment(MovieViewModel movie)
        {

            var user = await this._usrRepo.GetUser(movie.UserComment.Username);
            int id = movie.Id;
            Comment commentToAdd = new Comment
            {
                Content = movie.UserComment.Comment,
                User = user,
                AddedDate = movie.UserComment.AddedDate
            };

            await this._movieRepo.AddComment(movie.Id, commentToAdd);
            return RedirectToAction("ShowMovie", new { id = movie.Id });
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectToActionResult> AddRate(MovieViewModel movie)
        {

            var user = await this._usrRepo.GetUser(movie.UserRate.UserName);
            int id = movie.Id;

            if (await this._rateRepo.UserRated(id, user.UserName))
            {
                TempData["RateErrorData"] = "You already have rated this movie";
            }

            Rate rateToAdd = new Rate()
            {
                User = user,
                IfLike = movie.UserRate.Rate > 0 ? true : false
            };
            await this._rateRepo.AddRate(movie.Id, rateToAdd);
            return RedirectToAction("ShowMovie", new { id = movie.Id });
        }
        public async Task<IActionResult> SortMoviesByDateAsc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderBy(m => m.ReleaseDate));
        }

        public async Task<IActionResult> SortMoviesByDateDesc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderByDescending(m => m.ReleaseDate));
        }
        public async Task<IActionResult> SortMoviesByTitleAsc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderBy(m => m.Title));
        }
        public async Task<IActionResult> SortMoviesByTitleDesc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderByDescending(m => m.Title));
        }
        public async Task<IActionResult> SortMoviesByCategoryAsc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderBy(m => m.Category));
        }
        public async Task<IActionResult> SortMoviesByCategoryDesc()
        {
            var moviesViewModel = await getAllMovies();
            return View("Movies", moviesViewModel.OrderByDescending(m => m.Category));
        }
        private async Task<IEnumerable<MovieViewModel>> getAllMovies()
        {
            var allMovies = await this._movieRepo.AllMovies();
            List<MovieViewModel> moviesViewModel = new List<MovieViewModel>();
            foreach (var m in allMovies)
            {
                moviesViewModel.Add(new MovieViewModel(m));
            }
            return moviesViewModel;
        }
    }

}