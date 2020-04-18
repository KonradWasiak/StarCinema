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

        public IList<Cinema> AllCinemas(string orderBy)
        {
            switch (orderBy)
            {
                case "CityAsc":
                    return context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderBy(x => x.City.CityName)
                        .ToList();
                case "CityDesc":
                    return context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderByDescending(x => x.City.CityName)
                        .ToList();
                default:
                    return context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderBy(x => x.City.CityName)
                        .ToList();
            }
        }

        public Cinema FindCinema(int cinemaId)
        { 
            return context.Cinemas.Where(x => x.Id == cinemaId)
                .Include(x => x.Address)
                .Include(x => x.CinemaHalls)
                .FirstOrDefault();
        }

        public int CinemasCount()
        {
            return context.Cinemas.Count();
        }
        public IList<Cinema> FindCinemasFromCity(int cityId)
        {
            return context.Cinemas.Where(x => x.City.Id == cityId).ToList();
        }

        public IList<Cinema> PaginatedCinemas(int page, int pageSize, string orderBy)
        {
            var allCinemas = AllCinemas(orderBy);

            return allCinemas.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Cinema RemoveCinema(int cinemaId)
        {
            var cinemaToRemove = context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();
            if (cinemaToRemove != null)
                context.Cinemas.Remove(cinemaToRemove);
            
            context.SaveChanges();

            return cinemaToRemove;
        }
    }
}
