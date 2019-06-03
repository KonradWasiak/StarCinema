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
            var cities = await this._context.Cities.ToListAsync();
            return cities;
        }

        public async Task EditCity(City city)
        {
            var cityToEdit = await this._context.Cities
                                        .Include(c => c.Cinemas)
                                        .ThenInclude(ci => ci.CinemaHalls)
                                        .FirstOrDefaultAsync(c => c.CityName == city.CityName);
        }

        public Task<City> FindCity(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCity(City city)
        {
            throw new NotImplementedException();
        }
    }
}
