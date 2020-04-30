using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICityRepository
    {
        IList<City> PaginatedCities(int page, int pageSize, string orderBy);
        void AddCity(City city);
        City FindCity(int cityId);
        IList<City> AllCities(string orderBy);
        void RemoveCity(int cityId);
        void EditCity(City city);
        int CitiesCount();
    }
}