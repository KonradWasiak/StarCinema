using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.AddressModels;
using StarCinema.Models.CRUDModels.CinemaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public AddressModels.AddressViewModel Address { get; set; }
        public List<CinemaViewModel> Cinemas { get; set; }

        public CityViewModel(string cityName, List<Cinema> cinemas)
        {
            this.CityName = cityName;
            if (this.Cinemas == null)
            {
                cinemas.ForEach(x => this.Cinemas.Add(new CinemaViewModel(x)));
            }
        }

        public CityViewModel(string cityName)
        {
            this.CityName = cityName;
            this.Cinemas = null;
        }

        public CityViewModel(City city)
        {
            this.Id = city.Id;
            this.CityName = city.CityName;
            this.Cinemas = new List<CinemaViewModel>();
        }
        public CityViewModel()
        {

        }
    }
}
