using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.Models.CRUDModels.CinemaModels;

namespace StarCinema.DataLayer.Concrete
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly StarCinemaContext _context;

        public CinemaRepository(StarCinemaContext context)
        {
            this._context = context;
        }
        public void AddCinema(Cinema cinema)
        {
            this._context.Cinemas.Add(cinema);
            this._context.SaveChanges();
        }

        public IList<Cinema> AllCinemas(string orderBy)
        {
            switch (orderBy)
            {
                case "CityAsc":
                    return _context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderBy(x => x.City.CityName)
                        .ToList();
                case "CityDesc":
                    return _context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderByDescending(x => x.City.CityName)
                        .ToList();
                default:
                    return _context.Cinemas.Include(x => x.Address)
                        .Include(x => x.City)
                        .Include(x => x.CinemaHalls)
                        .OrderBy(x => x.City.CityName)
                        .ToList();
            }
        }

        public Cinema FindCinema(int cinemaId)
        { 
            return _context.Cinemas.Where(x => x.Id == cinemaId)
                .Include(x => x.Address)
                .Include(x => x.CinemaHalls)
                .ThenInclude(x => x.Shows)
                .Include(x => x.CinemaHalls)
                .ThenInclude(x => x.Seats)
                .FirstOrDefault();
        }

        public int CinemasCount()
        {
            return _context.Cinemas.Count();
        }
        public IList<Cinema> FindCinemasFromCity(int cityId)
        {
            return _context.Cinemas.Where(x => x.City.Id == cityId).ToList();
        }

        public IList<Cinema> PaginatedCinemas(int page, int pageSize, string orderBy)
        {
            var allCinemas = AllCinemas(orderBy);

            return allCinemas.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IList<Cinema> SearchCinema(string city)
        {
            return _context.Cinemas.Where(x => x.City.CityName.Contains(city))
                .Include(x => x.Address)
                .Include(x => x.City)
                .Include(x => x.CinemaHalls)
                .ToList();
        }

        public void EditCinema(int cinemaId, AddEditCinemaRequest cinema)
        {
            var cinemaToEdit = FindCinema(cinemaId);
            if (cinemaToEdit != null)
            {
                var newCity = _context.Cities.Where(x => x.Id == cinema.CityId).FirstOrDefault();
                cinemaToEdit.Address.Street = cinema.Street;
                cinemaToEdit.Address.BuildingNumber = cinema.BuildingNumber;
                cinemaToEdit.Address.PostalCode = cinema.PostalCode;
                cinemaToEdit.Address.City = newCity?.CityName;
                cinemaToEdit.City = newCity;

                foreach (var cinemaHall in cinema.CinemaHalls)
                { 
                    cinemaToEdit.CinemaHalls.Where(x => x.Id == cinemaHall.CinemaHallId).FirstOrDefault().Name = cinemaHall.Name;
                }

                _context.SaveChanges();
            }
        }

        public void AddHallsToCinema(int cinemaId, List<CinemaHall> halls)
        {
            var cinema = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();
            halls.ForEach(x => cinema.CinemaHalls.Add(x));
            _context.SaveChanges();
        }

        public Cinema RemoveCinema(int cinemaId)
        {
            var cinemaToRemove = _context.Cinemas.Where(x => x.Id == cinemaId).FirstOrDefault();
            if (cinemaToRemove != null)
                _context.Cinemas.Remove(cinemaToRemove);
            
            _context.SaveChanges();

            return cinemaToRemove;
        }

        public IList<Cinema> FindCinemaWithMovieShows(int movieId)
        {
            var shows = _context.Shows.Where(x => x.MovieId == movieId)
                .Include(x => x.Hall)
                .ThenInclude(x => x.Cinema)
                .ThenInclude(x => x.Address)
                .Include(x => x.Hall.Cinema.City)
                .ToList();
            var cinemas = shows.Select(x => x.Hall?.Cinema)
                .Distinct()
                .ToList();
            return cinemas;
        }
    }
}
