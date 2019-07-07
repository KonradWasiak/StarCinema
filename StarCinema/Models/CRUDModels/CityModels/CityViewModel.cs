using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class CityViewModel
    {
        public string CityName { get; set; }
        public List<Cinema> Cinemas { get; set; }

        public CityViewModel(string cityName, List<Cinema> cinemas)
        {
            this.CityName = cityName;
            this.Cinemas = cinemas;
        }

        public CityViewModel(string cityName)
        {
            this.CityName = cityName;
            this.Cinemas = null;
        }

        public CityViewModel(City city)
        {
            this.CityName = city.CityName;
            this.Cinemas = city.Cinemas.ToList();
        }
        public CityViewModel()
        {

        }
    }
}
