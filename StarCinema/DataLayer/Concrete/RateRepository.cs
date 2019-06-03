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

        public async Task AddRate(int movieId, Rate rate)
        {
            var movie = await FindMovie(movieId);
            if (!(await UserRated(movieId, rate.User.UserName)))
            {
                movie.Rates.Add(rate);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserRated(int movieId, string userName)
        {
            var movie = await FindMovie(movieId);
            var rates = movie.Rates.ToList();

            foreach (var r in rates)
            {
                if (r.User.UserName.Equals(userName))
                    return true;
            }
            return false;
        }

        private async Task<Movie> FindMovie(int id)
        {
            return await context.Movies.Include(m => m.Category)
                                                              .Include(m => m.Comments)
                                                              .Include(m => m.Rates)
                                                              .Include(m => m.Shows)
                                                              .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
