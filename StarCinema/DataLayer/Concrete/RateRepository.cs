using Microsoft.EntityFrameworkCore;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Concrete
{
    public class RateRepository : IRateRepository
    {
        private readonly StarCinemaContext context;

        public RateRepository(StarCinemaContext context)
        {
            this.context = context;
        }

        public void AddRate(int movieId, Rate rate)
        {
            var movie = FindMovie(movieId);
            if (!(UserRated(movieId, rate.User.UserName)))
            {
                movie.Rates.Add(rate); 
                context.SaveChangesAsync();
            }
        }

        public bool UserRated(int movieId, string userId)
        {
            var movie = FindMovie(movieId);
            var rates = movie.Rates.ToList();

            foreach (var r in rates)
            {
                if (r.User.Id.Equals(userId))
                    return true;
            }
            return false;
        }

        private Movie FindMovie(int id)
        {
            return context.Movies.Include(m => m.Category)
                                                              .Include(m => m.Comments)
                                                              .Include(m => m.Rates)
                                                              .Include(m => m.Shows)
                                                              .FirstOrDefault(m => m.Id == id);
        }

    }
}
