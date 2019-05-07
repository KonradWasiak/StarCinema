using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StarCinema.DomainModels;

namespace StarCinema.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the StarCinemaUser class
    public class StarCinemaUser : IdentityUser
    {
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
