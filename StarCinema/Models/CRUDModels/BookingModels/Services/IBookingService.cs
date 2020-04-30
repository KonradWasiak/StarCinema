using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.BookingModels.Services
{
    public interface IBookingService
    {
        string GetBookingHash(Booking booking);
    }
}
