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
    public class CinemaHallRepository : ICinemaHallRepository
    {
        private readonly StarCinemaContext context;

        public CinemaHallRepository(StarCinemaContext context)
        {
            this.context = context;
        }
        public async Task AddCinemaHallAsync(CinemaHall hall)
        {
            context.Halls.Add(hall);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CinemaHall>> AllCinemaHalls()
        {
            return await context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .ToListAsync();
        }

        public async Task<int> CinemaHallsCount()
        {
            return await context.Halls.CountAsync();
        }

        public async Task<IEnumerable<CinemaHall>> FindCinemaHallsFromCinema(Cinema cinema)
        {
            var cinemaTmp = context.Cinemas.Where(x => x.Id == cinema.Id);
            if(cinemaTmp == null)
            {
                return null;
            }
            return await context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .Where(x => x.Cinema.Id == cinema.Id).ToListAsync();
        }

        public async Task<IEnumerable<CinemaHall>> PaginatedCinemaHalls(Cinema cinema, int page, int itemsPerPage)
        {
            return await this.context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .Where(x => x.Cinema.Id == cinema.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<CinemaHall>> PaginatedCinemaHalls(int page, int itemsPerPage)
        {
            return await this.context.Halls
                            .Include(x => x.Shows)
                            .Include(x => x.Seats)
                            .Skip((page - 1) * itemsPerPage)
                            .Take(itemsPerPage)
                            .ToListAsync();
        }

        public async Task<CinemaHall> RemoveCinemaHall(CinemaHall hall)
        {
            var hallTmp = context.Halls.Where(x => x.Id == hall.Id).FirstOrDefault();
            if (hallTmp == null)
            {
                return null;
            }
            context.Halls.Remove(hallTmp);

            await context.SaveChangesAsync();

            return hallTmp;
        }
    }
}
