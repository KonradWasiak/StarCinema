using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.SeatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaHallModels
{
    public class CinemaHallFactory
    {
        private SeatFactory _seatFactory;

        public CinemaHallFactory(SeatFactory seatFactory)
        {
            this._seatFactory = seatFactory;
        }
        public CinemaHall CreateCinemaHall(CinemaHallViewModel hall)
        {
            var cinemaHall = new CinemaHall()
            {
                Shows = new List<Show>(),
                Cinema = null,
                Id = hall.Id,
                Name = hall.Name,
                Seats = new List<Seat>(hall.SeatsCount)
            };

            for (int i = 0; i < hall.SeatsCount; i++)
            {
                cinemaHall.Seats.Add(_seatFactory.GetSeat(cinemaHall));
            }

            return cinemaHall;
        }
    }
}
