using StarCinema.DataLayer.Abstract;
using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.AddressModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class CinemaFactory
    {
        private readonly ICityRepository _cityRepo;
        private readonly CinemaHallFactory _cinemaHallFactory;

        public CinemaFactory(ICityRepository cityRepo, CinemaHallFactory cinemaHallFactory)
        {
            _cityRepo = cityRepo;
            _cinemaHallFactory = cinemaHallFactory;
        }

        public Cinema CreateCinema(AddEditCinemaRequest request)
        {
            var cinema = new Cinema();
            cinema.CinemaHalls = new List<CinemaHall>();
            var city = _cityRepo.FindCity(request.CityId);

            request.CinemaHalls.ForEach(x => cinema.CinemaHalls.Add(_cinemaHallFactory.CreateCinemaHall(x)));
            cinema.City = city;
            cinema.Address = new Address()
            {
                BuildingNumber = request.BuildingNumber,
                City = city.CityName,
                PostalCode = request.PostalCode,
                Street = request.Street
            };
            return cinema;
        }
    }
}
