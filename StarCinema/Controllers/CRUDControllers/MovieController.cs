using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;
using StarCinema.Models.CRUDModels.CommentModels;
using StarCinema.Models.CRUDModels.IndexModels;
using StarCinema.Models.CRUDModels.MovieModels;
using StarCinema.Models.IndexModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IUserRepository _usrRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IRateRepository _rateRepo;
        private readonly ICommentRepository _commentRepo;
        private readonly MovieFactory _movieFactory;
        private readonly CommentFactory _commentFactory;


        public MovieController(IMovieRepository movieRepo, IUserRepository usrRepo, ICategoryRepository categoryRepo, 
            IRateRepository rateRepo, ICommentRepository commentRepo, MovieFactory movieFactory, CommentFactory commentFactory)
        {
            this._movieRepo = movieRepo;
            this._usrRepo = usrRepo;
            this._categoryRepo = categoryRepo;
            this._rateRepo = rateRepo;
            this._commentRepo = commentRepo;
            this._movieFactory = movieFactory;
            this._commentFactory = commentFactory;
        }
        public async Task<IActionResult> Movies(int id)
        {
            if (id == 0)
            {
                id = 1;
            }
            var movies = await _movieRepo.PaginatedMovies(id, PagingInfo.ItemsPerPage);            
            int moviesCount = await this._movieRepo.MoviesCount();

            List<MovieViewModel> moviesViewModel = new List<MovieViewModel>();

            movies.ForEach(x => moviesViewModel.Add(new MovieViewModel(x)));

            var paginatedMovies = new PaginatedViewModel<MovieViewModel>(moviesViewModel, id, moviesCount);
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
        public async Task<IActionResult> ShowMovie(int id, int commentsPage)
        {
            var movie = await this._movieRepo.FindMovie(id);
            var comments = await this._commentRepo.PaginatedComments(id, commentsPage, PagingInfo.ItemsPerPage);
            int commentsPagesCount = CalculatePagesCount(movie);

            var movieViewModel = new MovieViewModel(movie, new PagingInfo
            {
                CurrentPage = commentsPage,
                TotalPages = commentsPagesCount,
            });
            movieViewModel.Comments = comments.ToList();
            movieViewModel.CanRate = TempData["RateErrorData"] == null ? true : false;
            movieViewModel.TotalCommentsCount = movie.Comments.Count();

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
                var movieToAdd = await _movieFactory.GetMovie(movie);

                _movieRepo.AddMovie(movieToAdd);
                int id = movieToAdd.Id;
                var filePoster = movie.PosterImage;
                var fileBanner = movie.BannerImage;

                await ImagesManager.UploadPoster(filePoster, id, true);
                await ImagesManager.UploadBanner(fileBanner, id, true);
                var categories = await _categoryRepo.AllCategories();
                return View(new MovieViewModel(categories));
            }
            return View(movie);
        }


        [HttpPost]
        public async Task<ActionResult> RemoveMovie(int movieId)
        {
            var movieToDelete = await _movieRepo.FindMovie(movieId);
            await _movieRepo.RemoveMovie(movieToDelete);
            await ImagesManager.DeleteImages(movieId);
            return View(movieToDelete);
        }

        [HttpGet]
        public async Task<ActionResult> EditMovie(int movieId)
        {
            var movieToEdit = await _movieRepo.FindMovie(movieId);
            var categories = await _categoryRepo.AllCategories();

            return View(new MovieViewModel(categories, movieToEdit));
        }

        [HttpPost]
        public async Task<RedirectToActionResult> EditMovie(MovieViewModel movie)
        {
            var movieCategory = await _categoryRepo.FindCategory(movie.Category);
            var movietoEdit = await _movieFactory.GetMovie(movie);


            await this._movieRepo.EditMovie(movie.Id, movietoEdit);

            int id = movie.Id;
            var filePoster = movie.PosterImage;
            var fileBanner = movie.BannerImage;
            if (filePoster != null)
            {
                await ImagesManager.UploadPoster(filePoster, id, false);
            }

            if (fileBanner != null)
            {
                await ImagesManager.UploadBanner(fileBanner, id, false);
            }
            return RedirectToAction("Movies");
        }

        [Authorize]
        [HttpPost]
        public async Task<RedirectToActionResult> AddComment(MovieViewModel movie)
        {

            var user = await this._usrRepo.GetUser(movie.UserComment.Username);
            int id = movie.Id;
            var commentToAdd = await _commentFactory.GetComment(movie.UserComment);

            await this._movieRepo.AddComment(movie.Id, commentToAdd);
            return RedirectToAction("ShowMovie", new { id = movie.Id });
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<JsonResult> MovieComments([FromBody]MovieCommentsInputData inputData)
        {
            var movie = await _movieRepo.FindMovie(inputData.MovieId);
            var comments = movie.Comments.Skip(inputData.Page - 1 * PagingInfo.ItemsPerPage)
                .Take(PagingInfo.ItemsPerPage)
                .ToList();

            var commentsViewModel = new List<CommentViewModel>();

            comments.ForEach(x => commentsViewModel.Add(new CommentViewModel(x)));

            return Json(commentsViewModel);
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
        [HttpGet]
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
        private static int CalculatePagesCount(Movie movie)
        {
            return movie.Comments.Count() % PagingInfo.ItemsPerPage > 0 ? movie.Comments.Count() / PagingInfo.ItemsPerPage + 1 : movie.Comments.Count() / PagingInfo.ItemsPerPage;
        }
    }

}