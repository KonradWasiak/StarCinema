using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.ShowModel;
using StarCinema.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace StarCinema.Models.CRUDModels.BookingModels
{
    public class BookingListingRowViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string CinemaHall { get; set; }
        public string MovieTitle { get; set; }
        public int MovieId { get; set; }
        public string Code { get; set; }

        public BookingListingRowViewModel(Booking booking)
        {
            Id = booking.Id;
            Username = booking.User.UserName;
            Date = booking.Show.Date;
            CinemaHall = booking.Show.Hall.Cinema.City.CityName + " (" + booking.Show.Hall.Cinema.Address.Street + "): " + booking.Show.Hall.Name;
            MovieTitle = booking.Show.Movie.Title;
            MovieId = booking.Show.Movie.Id;
        }
    }
}
