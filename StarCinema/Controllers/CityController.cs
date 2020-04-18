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
        public IActionResult Cities(int id)
        {
            if (id == 0) id = 1;
            var cities = _repo.PaginatedCities(id, _itemsPerPage).ToList();            
            int citiesCount = _repo.CitiesCount();

            var citiesViewModelList = new List<CityViewModel>();
            cities.ForEach(x => citiesViewModelList.Add(new CityViewModel(x)));
            
            var paginatedCitiesViewModelList = new ListingViewModel<CityViewModel>(citiesViewModelList, id, citiesCount, "");

            return View(paginatedCitiesViewModelList);
        }
        [HttpPost]
        public IActionResult RemoveCity(int cityId)
        {
            _repo.RemoveCity(cityId);
            return RedirectToAction("Cities");
        }
        //public async Task<IActionResult> SortCitiesByDateAsc()
        //{
        //    var moviesViewModel = await getAllMovies();
        //    return View("Movies", moviesViewModel.OrderBy(m => m.ReleaseDate));
        //}

        //public async Task<IActionResult> SortMoviesByDateDesc()
        //{
        //    var moviesViewModel = await getAllMovies();
        //    return View("Movies", moviesViewModel.OrderByDescending(m => m.ReleaseDate));
        //}
    }
}