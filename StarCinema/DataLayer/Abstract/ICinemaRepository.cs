using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using StarCinema.Models.CRUDModels.CinemaModels;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICinemaRepository
    {
        void AddCinema(Cinema cinema);
        Cinema RemoveCinema(int cinemaId);
        IList<Cinema> AllCinemas(string orderBy);
        IList<Cinema> FindCinemasFromCity(int cityId);
        Cinema FindCinema(int cinemaId);
        int CinemasCount();
        IList<Cinema> PaginatedCinemas(int page, int itemsPerPage, string orderBy);
        IList<Cinema> SearchCinema(string city);
        IList<Cinema> FindCinemaWithMovieShows(int movieId);
        void EditCinema(int cinemaId, AddEditCinemaRequest cinema);
        void AddHallsToCinema(int cinemaId, List<CinemaHall> halls);
    }
}
