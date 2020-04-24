using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class SearchCinemaViewModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public int CinemaHallsCount { get; set; }
        public Coordinates Coordinates { get; set; }
        public SearchCinemaViewModel(Cinema cinema)
        {
            Id = cinema.Id;
            City = cinema.City.CityName;
            Street = cinema.Address.Street;
            PostalCode = cinema.Address.PostalCode;
            BuildingNumber = cinema.Address.BuildingNumber;
            CinemaHallsCount = cinema.CinemaHalls.Count;
        }
    }
}
