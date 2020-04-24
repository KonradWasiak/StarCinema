using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.ShowModel;
using StarCinema.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.BookingModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public ShowListingRowViewModel ShowListing { get; set; }
        public UserViewModel User { get; set; }

        public BookingViewModel(Booking booking)
        {
            //this.Id = booking.Id;
            //if(this.ShowListing == null)
            //{
            //    this.ShowListing = new ShowListingViewModel(booking.ShowListing);
            //}
            //if(this.User == null)
            //{
            //    this.User = new UserViewModel(booking.User);
            //}
        }
    }
}
