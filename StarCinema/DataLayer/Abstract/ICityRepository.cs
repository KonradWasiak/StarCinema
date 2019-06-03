using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    interface ICityRepository
    {
        Task AddCity(City city);
        Task<City> FindCity(string cityName);
        Task<List<City>> AllCities();
        Task RemoveCity(City city);
        Task EditCity(City city);
    }
}