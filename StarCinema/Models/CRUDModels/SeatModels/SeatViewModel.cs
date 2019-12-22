using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.SeatModels
{
    public class SeatViewModel
    {
        public int Id { get; set; }
        public bool Available { get; set; }
        public CinemaHallViewModel Hall { get; set; }

        public SeatViewModel(Seat seat)
        {
            this.Id = seat.Id;
            this.Available = seat.Available;

            if(this.Hall == null)
            {
                this.Hall = new CinemaHallViewModel(seat.Hall);
            }
        }
        public SeatViewModel()
        {

        }
    }
}
