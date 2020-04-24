using StarCinema.DomainModels;
using StarCinema.Models.BookingModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.ShowModel
{
    public class ShowListingRowViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public DateTime Date { get; set; }
        public string Hall { get; set; }

        public ShowListingRowViewModel(Show show)
        {
            Id = show.Id;
            MovieTitle = show.Movie.Title;
            Date = show.Date;
            Hall = show.Hall.Cinema.City.CityName + ", " + show.Hall.Name;
        }
    }
}
