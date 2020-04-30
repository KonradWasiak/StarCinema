using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCity(CityViewModel city)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCity", city);
            }
            var cityToAdd = _cityFactory.GetCity(city);
            _repo.AddCity(cityToAdd);
            return RedirectToAction("Cities");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Cities(CityListingRequest request)
        {
            var cities = _repo.PaginatedCities(request.Page, request.PageSize, request.OrderBy).ToList();            
            int citiesCount = _repo.CitiesCount();

            var citiesViewModelList = new List<CityViewModel>();
            cities.ForEach(x => citiesViewModelList.Add(new CityViewModel(x)));
            
            var paginatedCitiesViewModelList = new ListingViewModel<CityViewModel>(citiesViewModelList, request.Page, citiesCount, request.OrderBy);

            return View(paginatedCitiesViewModelList);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveCity(int cityId)
        {
            _repo.RemoveCity(cityId);
            return RedirectToAction("Cities");
        }
    }
}