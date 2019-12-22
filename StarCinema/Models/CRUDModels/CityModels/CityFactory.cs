using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CityModels
{
    public class CityFactory
    {
        public City GetCity(CityViewModel city)
        {
            return new City
            {
                CityName = city.CityName
            };
        }
    }
}
