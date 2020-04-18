using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using StarCinema.Models.CRUDModels.SeatModels;
using StarCinema.Models.CRUDModels.ShowModel;
using Microsoft.Extensions.DependencyInjection;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class AddCinemaViewModel
    {
        public int CinemaId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public int CinemaHallsCount { get; set; }
        public List<AddCinemaHallRequest> CinemaHalls { get; set; }
        public List<SelectListItem> AllCities { get; set; }
        public AddCinemaRequest Request { get; set; }
        public AddCinemaViewModel(List<City> citites)
        {
            AllCities = new List<SelectListItem>();
            citites.ForEach(c => AllCities.Add(GetCitySelectListItem(c)));
        }

        public AddCinemaViewModel()
        {
            
        }
        public AddCinemaViewModel(Cinema cinema, List<City> citites) : this(citites)
        {
            Request = new AddCinemaRequest();
            CinemaHalls = new List<AddCinemaHallRequest>();
            CinemaId = cinema.Id;
            CityId = cinema.CityId;
            Street = cinema.Address.Street;
            PostalCode = cinema.Address.PostalCode;
            BuildingNumber = cinema.Address.BuildingNumber;
            CinemaHallsCount = cinema.CinemaHalls.Count;
            cinema.CinemaHalls.ToList().ForEach(x => CinemaHalls.Add(new AddCinemaHallRequest(x)));
        }

        private SelectListItem GetCitySelectListItem(City city)
        {
            return new SelectListItem()
            {
                Text = city.CityName,
                Value = city.Id.ToString()
            };
        }
    }
}
