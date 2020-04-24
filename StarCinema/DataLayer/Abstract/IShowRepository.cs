using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.DataLayer.Abstract
{
    public interface IShowRepository
    {
        IList<Show> GetShowsBetweenDates(DateTime from, DateTime to);
        IList<Show> GetMovieShows(int movieId, string orderBy);
        Show GetShow(int showId);
        void AddShow(Show show);
        void DeleteShow(int showId);
        IList<Show> GetPaginatedShows(int movieId, string orderBy, int page, int pageSize);
        int GetMovieShowsCount(int movieId);
    }
}
