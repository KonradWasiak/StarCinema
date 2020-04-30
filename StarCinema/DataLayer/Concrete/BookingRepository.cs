using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;

namespace StarCinema.DataLayer.Concrete
{
    public class BookingRepository : IBookingRepository
    {
        private readonly StarCinemaContext _context;

        public BookingRepository(StarCinemaContext context)
        {
            _context = context;
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public IList<Booking> GetPaginatedBookings(int page, int pageSize, string orderBy, int movieId)
        {
            var allMovieBookings = _context.Bookings.Where(x => x.Show.Movie.Id == movieId)
                .Include(x => x.User)
                .Include(x => x.Show)
                .Include(x => x.Show.Hall)
                .Include(x => x.Show.Hall.Cinema)
                .Include(x => x.Show.Hall.Cinema.Address)
                .Include(x => x.Show.Hall.Cinema.City)
                .Include(x => x.Show.Movie)
                .ToList();

            switch (orderBy)
            {
                case "DateAsc":
                    allMovieBookings = allMovieBookings.OrderBy(x => x.Show.Date).ToList();
                    break;
                case "DateDesc":
                    allMovieBookings = allMovieBookings.OrderByDescending(x => x.Show.Date).ToList();
                    break;
                case "UsernameAsc":
                    allMovieBookings = allMovieBookings.OrderBy(x => x.User.UserName).ToList();
                    break;
                case "UsernameDesc":
                    allMovieBookings = allMovieBookings.OrderByDescending(x => x.User.UserName).ToList();
                    break;
                case "MovieTitleAsc":
                    allMovieBookings = allMovieBookings.OrderBy(x => x.Show.Movie.Title).ToList();
                    break;
                case "MovieTitleDesc":
                    allMovieBookings = allMovieBookings.OrderByDescending(x => x.Show.Movie.Title).ToList();
                    break;
                default:
                    allMovieBookings = allMovieBookings.OrderBy(x => x.Show.Date).ToList();
                    break;
            }

            return allMovieBookings.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int MovieBookingsCount(int movieId)
        {
            return _context.Bookings.Where(x => x.Show.Movie.Id == movieId).Count();
        }
    }
}
