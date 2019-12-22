using StarCinema.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DomainModels
{
    public class Booking
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show{ get; set; }
        public string UserId { get; set; }
        public virtual StarCinemaUser User{ get; set; }
    }
}
