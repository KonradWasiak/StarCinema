using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarCinema.DomainModels
{
    public class Seat
    {
        public int Id { get; set; }
        public int CinemaHallId { get; set; }
        public bool Available { get; set; }
        public virtual CinemaHall Hall { get; set; }
    }
}