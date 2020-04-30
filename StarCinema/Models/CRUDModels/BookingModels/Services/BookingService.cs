using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.BookingModels.Services
{
    public class BookingService : IBookingService
    {
        public string GetBookingHash(Booking booking)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(booking.Id.ToString());
            var hash = System.Convert.ToBase64String(plainTextBytes);
            return hash;
        }
    }
}
