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

        public async Task<IActionResult> Cinemas(int id)
        {
            var cinemas = await this._cinemaRepo.PaginatedCinemas(id, _itemsPerPage);
            int allCinemasCount = await this._cinemaRepo.CinemasCount();

            List<CinemaViewModel> cinemasViewModelList = new List<CinemaViewModel>();
            cinemas.ForEach(x => cinemasViewModelList.Add(CinemaViewModel.CreateListCinemaViewModel(x)));

            var cinemasViewModel = new PaginatedViewModel<CinemaViewModel>(cinemasViewModelList, id, allCinemasCount);

            return View(cinemasViewModel);
        }

        public IActionResult CinemasFromCity()
        {
            return View();
        }

        public async Task<IActionResult> AddCinema()
        {
            var cities = await _cityRepo.AllCities();
            return View(new AddCinemaViewModel(cities));
        }
        [HttpPost]
        public async Task<IActionResult> AddCinema(AddCinemaViewModel cinema)
        {
            await cinema.CreateCinemaHalls(_cityRepo);
            var cinemaTmp = new AddCinemaViewModel()
            {
                Address = cinema.Address,
                HallsCount = cinema.HallsCount
            };
            TempData["cinema"] = JsonConvert.SerializeObject(cinemaTmp);
            
            return View("AddHallsToCinema", cinema);
        }

        [HttpPost]
        public async Task<IActionResult> AddHallsToCinema(AddCinemaViewModel cinema)
        {
            var cinemaTmp = JsonConvert.DeserializeObject<AddCinemaViewModel>(TempData["cinema"].ToString()); 
            (cinemaTmp as AddCinemaViewModel).CinemaHalls = cinema.CinemaHalls;
            cinema.CreateSeatsInHalls();

            var cinemaEntity = await _cinemaFactory.GetCinema(cinemaTmp);

            _cinemaRepo.AddCinema(cinemaEntity);

            return View("AddCinemaConfirmation", cinemaTmp);

        }
        //[HttpPost]
        //public IActionResult RemoveCinema(CinemaViewModel cinema)
        //{
        //    ////var cinemaToRemove = cinema.ToEntity();
        //    //this._cinemaRepo.RemoveCinema(cinemaToRemove);
        //    //return View(cinemaToRemove);
        //}
        public IActionResult EditCinema()
        {
            return View();
        }
    }
}