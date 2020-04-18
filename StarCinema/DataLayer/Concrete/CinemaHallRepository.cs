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
        public void AddCinemaHallAsync(CinemaHall hall)
        {
            context.Halls.Add(hall); 
            context.SaveChangesAsync();
        }

        public IList<CinemaHall> AllCinemaHalls()
        {
            return context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .ToList();
        }

        public int CinemaHallsCount()
        {
            return context.Halls.Count();
        }

        public IList<CinemaHall> FindCinemaHallsFromCinema(Cinema cinema)
        {
            var cinemaTmp = context.Cinemas.Where(x => x.Id == cinema.Id);
            if(cinemaTmp == null)
            {
                return null;
            }
            return context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .Where(x => x.Cinema.Id == cinema.Id).ToList();
        }

        public IList<CinemaHall> PaginatedCinemaHalls(Cinema cinema, int page, int itemsPerPage)
        {
            return  this.context.Halls
                .Include(x => x.Shows)
                .Include(x => x.Seats)
                .Where(x => x.Cinema.Id == cinema.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }

        public IList<CinemaHall> PaginatedCinemaHalls(int page, int itemsPerPage)
        {
            return this.context.Halls
                            .Include(x => x.Shows)
                            .Include(x => x.Seats)
                            .Skip((page - 1) * itemsPerPage)
                            .Take(itemsPerPage)
                            .ToList();
        }

        public CinemaHall RemoveCinemaHall(CinemaHall hall)
        {
            var hallTmp = context.Halls.Where(x => x.Id == hall.Id).FirstOrDefault();
            if (hallTmp == null)
            {
                return null;
            }
            context.Halls.Remove(hallTmp);

            context.SaveChanges();

            return hallTmp;
        }
    }
}
