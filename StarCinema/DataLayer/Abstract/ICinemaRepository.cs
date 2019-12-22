using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface ICinemaRepository : IRepository
    {
        void AddCinema(Cinema cinema);
        Task<Cinema> RemoveCinema(Cinema cinema);
        Task<List<Cinema>> AllCinemas();
        Task<List<Cinema>> FindMoviesFromCity(string city);
        Task<int> CinemasCount();
        Task<List<Cinema>> PaginatedCinemas(int page, int itemsPerPage);
    }
}
