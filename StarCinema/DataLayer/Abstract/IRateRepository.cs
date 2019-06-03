using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface IRateRepository
    {
        Task<bool> UserRated(int movieId, string userName);
        Task AddRate(int movieId, Rate rate);

    }
}
