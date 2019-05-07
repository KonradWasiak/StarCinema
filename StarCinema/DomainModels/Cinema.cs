using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarCinema.DomainModels
{
    public class Cinema
    {
        public int Id { get; set; }
        public City City { get; set; }
        public virtual int CityId { get; set; }
        public virtual ICollection<CinemaHall> CinemaHalls { get; set; }
    }
}