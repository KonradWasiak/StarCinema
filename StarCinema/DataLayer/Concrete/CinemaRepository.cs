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
    public class CinemaRepository : ICinemaRepository
    {
        private readonly StarCinemaContext context;

        public CinemaRepository(StarCinemaContext context)
        {
            this.context = context;
        }
        public void AddCinema(Cinema cinema)
        {
            this.context.Cinemas.Add(cinema);
            this.context.SaveChanges();
        }

        public async Task<List<Cinema>> AllCinemas()
        {
            return await context.Cinemas.ToListAsync();
        }

        public Task<int> CinemasCount()
        {
            return context.Cinemas.CountAsync();
        }
        public async Task<List<Cinema>> FindMoviesFromCity(string cityName)
        {
            var city = await context.Cities.Where(x => x.CityName == cityName).FirstOrDefaultAsync();
            return await context.Cinemas.Where(x => x.City == city).ToListAsync();
        }

        public async Task<List<Cinema>> PaginatedCinemas(int page, int itemsPerPage)
        {
            return await context.Cinemas.Include(c => c.City)
                .Include(c => c.CinemaHalls)
                .Include(c => c.Address)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        public async Task<Cinema> RemoveCinema(Cinema cinema)
        {
            var cinemaToRemove = context.Cinemas.Where(x => x.Id == cinema.Id).FirstOrDefault();
            if (cinemaToRemove != null)
                context.Cinemas.Remove(cinemaToRemove);

            await context.SaveChangesAsync();

            return cinemaToRemove;
        }
    }
}
