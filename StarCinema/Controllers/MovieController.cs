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
using Microsoft.Extensions.Configuration;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;
using StarCinema.Models.CRUDModels.CommentModels;
using StarCinema.Models.CRUDModels.IndexModels;
using StarCinema.Models.CRUDModels.MovieModels;
using StarCinema.Models.CRUDModels.RateModels;
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
        private readonly IConfiguration _config;
        private int _itemsPerPage;

        public MovieController(IMovieRepository movieRepo, IUserRepository usrRepo, ICategoryRepository categoryRepo, 
            IRateRepository rateRepo, ICommentRepository commentRepo, MovieFactory movieFactory, CommentFactory commentFactory, IConfiguration configuration)
        {
            this._movieRepo = movieRepo;
            this._usrRepo = usrRepo;
            this._categoryRepo = categoryRepo;
            this._rateRepo = rateRepo;
            this._commentRepo = commentRepo;
            this._movieFactory = movieFactory;
            this._commentFactory = commentFactory;
            this._config = configuration;
            this._itemsPerPage = _config.GetValue<int>("ItemsPerPage");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Movies(MovieListingRequest request)
        {
            var movies = _movieRepo.PaginatedMovies(request.Page, request.PageSize, request.OrderBy).ToList();            
            int moviesCount = this._movieRepo.MoviesCount();

            var moviesViewModel = new List<MovieListingViewModel>();

            movies.ForEach(x => moviesViewModel.Add(new MovieListingViewModel(x)));

            var paginatedMovies = new ListingViewModel<MovieListingViewModel>(moviesViewModel, request.Page, moviesCount, "TitleAsc");
            return View(paginatedMovies);
        }

        [HttpGet]
        public IActionResult MoviesFromCategory(int categoryId)
        {
            var movies = this._categoryRepo.FindMoviesFromCategory(categoryId);
            var categoryName = _categoryRepo.FindCategory(categoryId).CategoryName;
            var moviesViewModel = new MoviesFromCategoryViewModel()
            {
                CategoryName = categoryName,
                MoviesFromCategory = movies
            };

            return View(moviesViewModel);
        }

        public IActionResult ShowMovie(ShowMovieRequest request)
        {
            var movie = this._movieRepo.FindMovie(request.MovieId);
            var comments = this._commentRepo.PaginatedComments(request.MovieId, request.CommentPage, request.PageSize, "AddedDateDesc").ToList();

            var movieViewModel = new ShowMovieViewModel(movie, request.CommentPage, movie.Comments.Count());
            comments.ForEach(x => movieViewModel.Comments.Add(new ShowMovieCommentViewModel(x)));
            movieViewModel.CanUserRate = TempData["RateErrorData"] == null ? true : false;
            movieViewModel.AddComentViewModel.MovieId = request.MovieId;

            TempData["RateErrorData"] = null;
            return View(movieViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie()
        {
            var categories = this._categoryRepo.AllCategories().ToList();
            return View(new AddEditMovieViewModel(categories));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie(AddEditMovieRequest request)
        {
            if (ModelState.IsValid)
            {
                var movieToAdd = _movieFactory.CreateMovie(request);

                _movieRepo.AddMovie(movieToAdd);
                int id = movieToAdd.Id;
                var filePoster = request.PosterImage;
                var fileBanner = request.BannerImage;

                ImagesManager.UploadPoster(filePoster, id, true);
                ImagesManager.UploadBanner(fileBanner, id, true);
                return RedirectToAction("Movies");
            }

            var categories = _categoryRepo.AllCategories().ToList();
            var movie = new AddEditMovieViewModel(categories, request);

            return View(movie);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveMovie(int movieId)
        {
            var movieToDelete =  _movieRepo.FindMovie(movieId); 
            _movieRepo.RemoveMovie(movieId);
            ImagesManager.DeleteImages(movieId);
            return View(movieToDelete);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditMovie(int movieId)
        {
            var movie = _movieRepo.FindMovie(movieId);
            var categories = _categoryRepo.AllCategories().ToList();

            return View(new AddEditMovieViewModel(categories, movie));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public RedirectToActionResult EditMovie(AddEditMovieViewModel addEditMovie)
        {
            var movietoEdit = _movieFactory.CreateMovie(addEditMovie.Request);

            this._movieRepo.EditMovie(addEditMovie.Request.Id, movietoEdit);

            int id = addEditMovie.Request.Id;
            var filePoster = addEditMovie.Request.PosterImage;
            var fileBanner = addEditMovie.Request.BannerImage;
            if (filePoster != null)
            { 
                ImagesManager.UploadPoster(filePoster, id, false);
            }

            if (fileBanner != null)
            { 
                ImagesManager.UploadBanner(fileBanner, id, false);
            }
            return RedirectToAction("Movies");
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult AddComment(AddComentRequest request)
        {

            var user = this._usrRepo.GetUser(request.User);
            int id = request.MovieId;
            var commentToAdd = _commentFactory.CreateComment(request);
            
            this._movieRepo.AddComment(request.MovieId, commentToAdd);
            return RedirectToAction("ShowMovie", new ShowMovieRequest(){ MovieId = request.MovieId });
        }

        [Authorize]
        [HttpPost]
        public RedirectToActionResult AddRate(AddRateRequest request)
        {
            this.ViewData["ReturnUrl"] = "";

            var user = this._usrRepo.GetUser(request.Username);
            if (!this._rateRepo.UserRated(request.MovieId, user.Id))
            {            
                Rate rateToAdd = new Rate()
                {
                    User = user,
                    IfLike = request.ThumbUp
                }; 
                _rateRepo.AddRate(request.MovieId, rateToAdd);
                return RedirectToAction("ShowMovie", new ShowMovieRequest() { MovieId = request.MovieId });

            }
            TempData["RateErrorData"] = "You already have rated this addEditMovie";

            return RedirectToAction("ShowMovie", new ShowMovieRequest() {MovieId = request.MovieId});
        }

        [HttpGet]
        public IActionResult SearchMovies(string movieTitle)
        {
            var movies = _movieRepo.SearchMovies(movieTitle);
            var moviesSearchList = new List<SearchMoviesViewModel>();
            movies.ToList().ForEach(x => moviesSearchList.Add(new SearchMoviesViewModel(x)));
            return View(moviesSearchList);
        }
    }
}