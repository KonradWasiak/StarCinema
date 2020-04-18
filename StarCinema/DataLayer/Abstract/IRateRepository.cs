using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface IRateRepository
    {
        bool UserRated(int movieId, string userId);
        void AddRate(int movieId, Rate rate);

    }
}
