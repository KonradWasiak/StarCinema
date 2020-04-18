using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.CinemaModels;

namespace StarCinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepo;
        private readonly ICityRepository _cityRepo;
        private readonly CinemaFactory _cinemaFactory;
        private readonly IConfiguration _config;
        private int _itemsPerPage;
        public CinemaController(ICinemaRepository cinemaRepo, ICityRepository cityRepo, CinemaFactory cinemaFactory, IConfiguration configuration)
        {
            this._cinemaRepo = cinemaRepo;
            this._cityRepo = cityRepo;
            this._cinemaFactory = cinemaFactory;
            this._config = configuration;
            this._itemsPerPage = _config.GetValue<int>("ItemsPerPage");
        }

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
        public IActionResult AddCinema()
        {
            var cities = _cityRepo.AllCities().ToList();
            return View(new AddCinemaViewModel(cities));
        }

        [HttpPost]
        public IActionResult AddHallsToCinema(AddCinemaRequest request)
        {            
            request.CreateCinemaHalls();
            return View("AddHallsToCinema", request);
        }

        [HttpPost]
        public IActionResult AddCinema(AddCinemaRequest request)
        {
            var cinema = _cinemaFactory.CreateCinema(request);

            _cinemaRepo.AddCinema(cinema);

            return RedirectToAction("Cinemas");
        }


        [HttpPost]
        public IActionResult RemoveCinema(int cinemaId)
        {
            this._cinemaRepo.RemoveCinema(cinemaId);
            return RedirectToAction("Cinemas");
        }

        [HttpGet]
        public IActionResult EditCinema(int cinemaId)
        {
            var cinema = _cinemaRepo.FindCinema(cinemaId);
            var cities = _cityRepo.AllCities().ToList();
            var editCinemaViewModel = new AddCinemaViewModel(cinema, cities);
            return View(editCinemaViewModel);
        }


        [HttpPost]
        public IActionResult EditCinema(AddCinemaViewModel editCinemaViewModel)
        {
            return View();
        }
    }
}