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
        public CinemaHall CreateCinemaHall(AddEditCinemaHallRequest request)
        {
            var cinemaHall = new CinemaHall()
            {
                Shows = new List<Show>(),
                Cinema = null,
                Name = request.Name,
                Seats = new List<Seat>(request.SeatsCount)
            };

            for (int i = 0; i < request.SeatsCount; i++)
            {
                cinemaHall.Seats.Add(new Seat()
                {
                    Available = true,
                    Hall = cinemaHall
                });
            }

            return cinemaHall;
        }
    }
}
