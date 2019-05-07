using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarCinema.DomainModels
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int CinemaId { get; set; }
        public virtual Cinema Cinema{ get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Show> Shows{ get; set; }
    }
}