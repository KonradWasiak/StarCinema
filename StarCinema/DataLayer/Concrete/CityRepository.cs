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

        public async Task AddCity(City city)
        {
            await this._context.Cities.AddAsync(city);
            await this._context.SaveChangesAsync();

        }

        public async Task<List<City>> AllCities()
        {
            var cities = await this._context.Cities
                                   .Include(c => c.Cinemas)
                                   .ToListAsync();
            return cities;
        }

        public async Task<int> CitiesCount()
        {
            return await this._context.Cities.CountAsync();

        }

        public async Task EditCity(City city)
        {
            var cityToEdit = await this._context.Cities
                                        .Include(c => c.Cinemas)
                                        .ThenInclude(ci => ci.CinemaHalls)
                                        .FirstOrDefaultAsync(c => c.CityName == city.CityName);
        }

        public async Task<City> FindCity(string cityName)
        {
            return await this._context
                             .Cities
                             .FirstOrDefaultAsync(c => c.CityName.Equals(cityName));
        }

        public async Task<List<City>> PaginatedCities(int page, int itemsPerPage)
        {
            return await this._context.Cities.Include(c => c.Cinemas)
                                                .Skip((page - 1) * itemsPerPage)
                                                .Take(itemsPerPage)
                                                .ToListAsync();
        }

        public async Task RemoveCity(City city)
        {
            var cityToDelete = await this._context
                                    .Cities
                                    .FirstOrDefaultAsync(c => c.CityName.Equals(city.CityName));
            this._context.Cities
                         .Remove(cityToDelete);
            await this._context.SaveChangesAsync();
        }
    }
}
