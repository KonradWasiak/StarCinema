using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class ShowForBookingRowViewModel
    {
        public int ShowId { get; set; }
        public DateTime Date { get; set; }
        public bool isAvailable { get; set; }

        public ShowForBookingRowViewModel(Show show)
        {
            ShowId = show.Id;
            Date = show.Date;
            isAvailable = (show.Bookings.Count) < (show.Hall.Seats.Count);
        }
    }
}
