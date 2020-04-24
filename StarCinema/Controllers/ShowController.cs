using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.ShowModel;
using StarCinema.Models.CRUDModels.ShowModels;

namespace StarCinema.Controllers
{
    public class ShowController : Controller
    {
        private readonly IShowRepository _showRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly ShowFactory _showFactory;
        public ShowController(IShowRepository showRepository, IMovieRepository movieRepository, 
            ICinemaHallRepository cinemaHallRepository, ShowFactory showFactory)
        {
            _showRepository = showRepository;
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaHallRepository;
            _showFactory = showFactory;
        }

        [HttpGet]
        public IActionResult Shows(ShowListingRequest request)
        {
            var shows = _showRepository.GetPaginatedShows(request.MovieId, request.OrderBy, request.Page, request.PageSize).ToList();
            var showsCount = _showRepository.GetMovieShowsCount(request.MovieId);
            var showsViewModel = new List<ShowListingRowViewModel>();
            shows.ForEach(x => showsViewModel.Add(new ShowListingRowViewModel(x)));
            var showListingViewModel = new ShowListingViewModel(showsViewModel, request.Page, showsCount, request.OrderBy, request.MovieId);
            return View(showListingViewModel);
        }

        [HttpGet]
        public IActionResult AddShow(int movieId)
        {
            var cinemaHalls = _cinemaHallRepository.AllCinemaHalls().ToList();
            var addShowViewModel = new AddEditShowViewModel(cinemaHalls, movieId); 
            return View(addShowViewModel);
        }

        [HttpPost]
        public IActionResult AddShow(AddEditShowViewModel addEditShowViewModel)
        {
            var show = _showFactory.CreateShow(addEditShowViewModel.Request);
            var movieDuration = _movieRepository.FindMovie(addEditShowViewModel.Request.MovieId).DurationTime;
            bool isDateCorrect = !_showRepository.GetShowsBetweenDates(addEditShowViewModel.Request.Date,
                addEditShowViewModel.Request.Date.AddMinutes(movieDuration)).ToList().Any();

            if (!isDateCorrect)
            {
                var cinemaHalls = _cinemaHallRepository.AllCinemaHalls().ToList();
                var addShowViewModel = new AddEditShowViewModel(cinemaHalls, addEditShowViewModel.Request.MovieId);
                ModelState.AddModelError("Date", "There is already show with selected date and time");
                return View(addShowViewModel);
            }
            _showRepository.AddShow(show);
            return RedirectToAction("Shows", new ShowListingRequest(){MovieId = addEditShowViewModel.Request.MovieId});
        }

        [HttpGet]
        public IActionResult RemoveShow(int showId, int MovieId)
        {
            _showRepository.DeleteShow(showId);
            return RedirectToAction("Shows", new ShowListingRequest() { MovieId = MovieId });
        }

    }
}