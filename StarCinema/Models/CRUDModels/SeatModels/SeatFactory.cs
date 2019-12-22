using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.SeatModels
{
    public class SeatFactory
    {
        public Seat GetSeat(CinemaHall hall)
        {
            return new Seat()
            {
                Available = true,
                Hall = hall
            };
        }
    }
}
