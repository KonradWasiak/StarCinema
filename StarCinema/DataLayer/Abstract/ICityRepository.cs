using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICityRepository : IRepository
    {
        Task<List<City>> PaginatedCities(int page, int itemsPerPage);
        Task AddCity(City city);
        Task<City> FindCity(string cityName);
        Task<List<City>> AllCities();
        Task RemoveCity(City city);
        Task EditCity(City city);
        Task<int> CitiesCount();
    }
}