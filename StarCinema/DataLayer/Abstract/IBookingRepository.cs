using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.DataLayer.Abstract
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        IList<Booking> GetPaginatedBookings(int page, int pagesize, string orderBy, int movieId);
        int MovieBookingsCount(int movieId);
    }
}
