using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using StarCinema.Models.CRUDModels.CinemaModels;

namespace StarCinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepo;
        private readonly ICityRepository _cityRepo;
        private readonly CinemaFactory _cinemaFactory;
        private readonly CinemaHallFactory _cinemaHallFactory;
        private readonly IConfiguration _config;
        private readonly IGeolocationService _geolocationService;
        public CinemaController(ICinemaRepository cinemaRepo, ICityRepository cityRepo, 
            CinemaFactory cinemaFactory, IConfiguration configuration, IGeolocationService geolocationService,
            CinemaHallFactory cinemaHallFactory)
        {
            _cinemaRepo = cinemaRepo;
            _cityRepo = cityRepo;
            _cinemaFactory = cinemaFactory;
            _cinemaHallFactory = cinemaHallFactory;
            _config = configuration;
            _geolocationService = geolocationService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Cinemas([FromQuery] CinemaListingRequest request)
        {
            var cinemas =  this._cinemaRepo.PaginatedCinemas(request.Page, request.PageSize, request.OrderBy).ToList();
            int allCinemasCount = this._cinemaRepo.CinemasCount();

            List<CinemaViewModel> cinemasViewModelList = new List<CinemaViewModel>();
            cinemas.ForEach(x => cinemasViewModelList.Add(CinemaViewModel.CreateListCinemaViewModel(x)));

            var cinemasViewModel = new ListingViewModel<CinemaViewModel>(cinemasViewModelList, request.Page, allCinemasCount, request.OrderBy);

            return View(cinemasViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> SearchCinema(string city)
        {
            var cinemas = _cinemaRepo.SearchCinema(city).ToList();
            var cinemasViewModel = new List<SearchCinemaViewModel>();
            cinemas.ForEach(x => cinemasViewModel.Add(new SearchCinemaViewModel(x)));

            foreach (var cinema in cinemasViewModel)
            {
                cinema.Coordinates = await _geolocationService.GetCoordinates(cinema.City, cinema.Street, cinema.BuildingNumber);
            }

            return View(cinemasViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChooseCinemaForBooking(int movieId)
        {
            var cinemasWithMovie = _cinemaRepo.FindCinemaWithMovieShows(movieId).ToList();
            var chooseCinemaViewModel = new ChooseCinemaForBookingViewModel(cinemasWithMovie, movieId);
            return View(chooseCinemaViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCinema()
        {
            var cities = _cityRepo.AllCities("").ToList();
            return View(new AddEditCinemaViewModel(cities));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddHallsToCinema(AddEditCinemaRequest request)
        {            
            request.CreateCinemaHalls();
            return View("AddHallsToCinema", request);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCinema(AddEditCinemaRequest request)
        {
            var cinema = _cinemaFactory.CreateCinema(request);

            _cinemaRepo.AddCinema(cinema);

            return RedirectToAction("Cinemas");
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveCinema(int cinemaId)
        {
            this._cinemaRepo.RemoveCinema(cinemaId);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCinema(int cinemaId)
        {
            var cinema = _cinemaRepo.FindCinema(cinemaId);
            var cities = _cityRepo.AllCities("").ToList();
            var editCinemaViewModel = new AddEditCinemaViewModel(cinema, cities);
            return View(editCinemaViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCinema(AddEditCinemaViewModel addEditCinemaViewModel)
        {
            _cinemaRepo.EditCinema(addEditCinemaViewModel.Request.CinemaId, addEditCinemaViewModel.Request);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddHallsToExistingCinema(int hallsCount, int cinemaId)
        {
            var addEditCinemaViewModel = new AddEditCinemaViewModel()
            {
                CinemaId = cinemaId,
                CinemaHallsCount = hallsCount
            };

            return View(addEditCinemaViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddHallsToExistingCinema(AddEditCinemaViewModel addEditCinemaViewModel)
        {
            var cinema = _cinemaRepo.FindCinema(addEditCinemaViewModel.Request.CinemaId);
            var newHalls = new List<CinemaHall>();
            addEditCinemaViewModel.Request.CinemaHalls.ForEach(x => newHalls.Add(_cinemaHallFactory.CreateCinemaHall(x)));
            _cinemaRepo.AddHallsToCinema(cinema.Id, newHalls);
            return RedirectToAction("Cinemas");
        }
    }
}