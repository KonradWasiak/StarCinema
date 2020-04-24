using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.CinemaHallModels
{
    public class AddEditCinemaHallRequest
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }

        public AddEditCinemaHallRequest()
        {
            
        }
        public AddEditCinemaHallRequest(CinemaHall cinemaHall)
        {
            Name = cinemaHall.Name;
            SeatsCount = cinemaHall.Seats.Count();
        }
    }
}
