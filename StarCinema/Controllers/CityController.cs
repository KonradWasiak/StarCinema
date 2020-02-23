using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;
using StarCinema.Models.CRUDModels.CityModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _repo;
        private readonly CityFactory _cityFactory;
        private readonly IConfiguration _config;
        private int _itemsPerPage;
        public CityController(ICityRepository cityRepo, CityFactory cityFactory, IConfiguration configuration)
        {
            this._repo = cityRepo;
            this._cityFactory = cityFactory;
            this._config = configuration;
            this._itemsPerPage = _config.GetValue<int>("ItemsPerPage");
        }

        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityViewModel city)
        {
            var cityToAdd = _cityFactory.GetCity(city);
            await _repo.AddCity(cityToAdd);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cities(int id)
        {
            if (id == 0) id = 1;
            var cities = await _repo.PaginatedCities(id, _itemsPerPage);            
            int citiesCount = await _repo.CitiesCount();

            var citiesViewModelList = new List<CityViewModel>();
            cities.ForEach(x => citiesViewModelList.Add(new CityViewModel(x)));
            
            var paginatedCitiesViewModelList = new PaginatedViewModel<CityViewModel>(citiesViewModelList, id, citiesCount);

            return View(paginatedCitiesViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCity(string cityName)
        {
            var cityToRemove = await _repo.FindCity(cityName);
            await _repo.RemoveCity(cityToRemove);
            return RedirectToAction("Cities");
        }
    }
}