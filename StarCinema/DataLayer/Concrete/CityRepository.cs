using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Concrete
{
    public class CityRepository : ICityRepository
    {
        private readonly StarCinemaContext _context;

        public CityRepository(StarCinemaContext context)
        {
            this._context = context;
        }

        public void AddCity(City city)
        {
            this._context.Cities.AddAsync(city);
            this._context.SaveChanges();

        }

        public IList<City> AllCities(string orderBy)
        {
            var cities = this._context.Cities
                .Include(c => c.Cinemas)
                .ToList();
            switch (orderBy)
            {
                case "CityNameAsc":
                    cities = cities.OrderBy(x => x.CityName).ToList();
                    break;
                case "CityNameDesc":
                    cities = cities.OrderByDescending(x => x.CityName).ToList();
                    break;
                default:
                    cities = cities.OrderBy(x => x.CityName).ToList();
                    break;
            }

            return cities;
        }

        public int CitiesCount()
        {
            return this._context.Cities.Count();

        }

        public void EditCity(City city)
        {
            var cityToEdit = this._context.Cities
                                        .Include(c => c.Cinemas)
                                        .ThenInclude(ci => ci.CinemaHalls)
                                        .FirstOrDefault(c => c.CityName == city.CityName);
        }

        public City FindCity(int cityId)
        {
            return this._context
                             .Cities
                             .FirstOrDefault(c => c.Id == cityId);
        }

        public IList<City> PaginatedCities(int page, int pageSize, string orderBy)
        {
            var citiest = AllCities(orderBy);

            return citiest.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public void RemoveCity(int cityId)
        {
            var cityToDelete = FindCity(cityId);
            this._context.Cities
                         .Remove(cityToDelete);

            this._context.SaveChanges();
        }
    }
}
