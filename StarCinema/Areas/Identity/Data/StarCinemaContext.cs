using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarCinema.Areas.Identity.Data;
using StarCinema.DomainModels;

namespace StarCinema.Models
{
    public class StarCinemaContext : IdentityDbContext<StarCinemaUser>
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CinemaHall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Show> Shows{ get; set; }
        public DbSet<City> Cities { get; set; }




        public StarCinemaContext(DbContextOptions<StarCinemaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
