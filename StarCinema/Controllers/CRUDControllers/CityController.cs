using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using StarCinema.Models.CRUDModels;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _repo;

        public CityController(ICityRepository cityRepo)
        {
            this._repo = cityRepo;
        }

        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityViewModel city)
        {
            await this._repo.AddCity(new City
            {
                CityName = city.CityName
            });
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cities(int id)
        {
            if (id == 0) id = 1;
            var cities = await this._repo.PaginatedCities(id, PagingInfo.ItemsPerPage);
            var citiesViewModelList = new List<CityViewModel>();

            foreach (var c in cities)
            {
                citiesViewModelList.Add(new CityViewModel(c));
            }

            int citiesCount = await this._repo.CitiesCount();
            int totalPages = citiesCount % PagingInfo.ItemsPerPage > 0 ? citiesCount / PagingInfo.ItemsPerPage + 1 : citiesCount / PagingInfo.ItemsPerPage;

            var paginatedCitiesViewModelList = new PaginatedCitiesViewModel(citiesViewModelList,
                new PagingInfo
                {
                    CurrentPage = id,
                    TotalPages = totalPages
                }
            );

            return View(paginatedCitiesViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCity(string cityName)
        {
            var cityToRemove = await this._repo.FindCity(cityName);
            await this._repo.RemoveCity(cityToRemove);
            return RedirectToAction("Cities");
        }
    }
}