using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;

namespace StarCinema.DataLayer.Concrete
{
    public class ShowRepository : IShowRepository
    {
        private readonly StarCinemaContext _context;

        public ShowRepository(StarCinemaContext context)
        { 
            _context = context;
        }

        public IList<Show> GetShowsBetweenDates(DateTime from, DateTime to, int cinemaHallId)
        {
            var allShows = _context.Shows.Where(x => x.Hall.Id == cinemaHallId).ToList();

            return _context.Shows.Where(x => (x.Date >= from && x.Date <= to))
                .Where(x => x.Hall.Id == cinemaHallId)
                .Include(x => x.Movie)
                .Include(x => x.Bookings)
                .Include(x => x.Hall)
                .ToList();
        }

        public IList<Show> GetMovieShows(int movieId, string orderBy)
        {
            var shows = _context.Shows.Where(x => x.Movie.Id == movieId)
                .Include(x => x.Movie)
                .Include(x => x.Bookings)
                .Include(x => x.Hall)
                .ThenInclude(x => x.Cinema)
                .ThenInclude(x => x.City)
                .ToList();

            switch (orderBy)
            {
                case "DateAsc":
                    return shows.OrderBy(x => x.Date).ToList();
                case "DateDesc":
                    return shows.OrderByDescending(x => x.Date).ToList();
                default:
                    return shows.OrderBy(x => x.Date).ToList();
            }
        }

        public Show GetShow(int showId)
        {
            return _context.Shows.Where(x => x.Id == showId)
                .Include(x => x.Movie)
                .Include(x => x.Bookings)
                .Include(x => x.Hall)
                .FirstOrDefault();
        }

        public void AddShow(Show show)
        {
            _context.Shows.Add(show);
            _context.SaveChanges();
        }

        public void DeleteShow(int showId)
        {
            var show = GetShow(showId);
            _context.Remove(show);
            _context.SaveChanges();
        }

        public IList<Show> GetPaginatedShows(int movieId, string orderBy, int page, int pageSize)
        {
            return GetMovieShows(movieId, orderBy).Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetMovieShowsCount(int movieId)
        {
            return _context.Shows.Where(x => x.Movie.Id == movieId).ToList().Count();
        }
    }
}
