using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DomainModels
{
    public class Show
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public virtual CinemaHall Hall { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
