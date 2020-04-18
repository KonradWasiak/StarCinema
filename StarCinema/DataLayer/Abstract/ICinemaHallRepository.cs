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
    public interface ICinemaHallRepository
    {
        void AddCinemaHallAsync(CinemaHall hall);
        CinemaHall RemoveCinemaHall(CinemaHall hall);
        IList<CinemaHall> AllCinemaHalls();
        IList<CinemaHall> FindCinemaHallsFromCinema(Cinema cinema);
        int CinemaHallsCount();
        IList<CinemaHall> PaginatedCinemaHalls(Cinema cinema, int page, int itemsPerPage);
        IList<CinemaHall> PaginatedCinemaHalls(int page, int itemsPerPage);
    }
}
