using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    /// <summary>
    /// Interface of cinema hall repository - it is an abstract intermediate layer between the database and the controllers
    /// </summary>
    public interface ICinemaHallRepository : IRepository
    {
        Task AddCinemaHallAsync(CinemaHall hall);
        Task<CinemaHall> RemoveCinemaHall(CinemaHall hall);
        Task<IEnumerable<CinemaHall>> AllCinemaHalls();
        Task<IEnumerable<CinemaHall>> FindCinemaHallsFromCinema(Cinema cinema);
        Task<int> CinemaHallsCount();
        Task<IEnumerable<CinemaHall>> PaginatedCinemaHalls(Cinema cinema, int page, int itemsPerPage);
        Task<IEnumerable<CinemaHall>> PaginatedCinemaHalls(int page, int itemsPerPage);
    }
}
