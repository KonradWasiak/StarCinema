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
        private readonly AddressFactory _addressFactory;

        public CinemaFactory(ICityRepository cityRepo, CinemaHallFactory cinemaHallFactory, AddressFactory addressFactory)
        {
            _cityRepo = cityRepo;
            _cinemaHallFactory = cinemaHallFactory;
            _addressFactory = addressFactory;
        }

        public async Task<Cinema> GetCinema(AddCinemaViewModel cinemaViewModel)
        {
            var cinema = new Cinema();
            cinema.CinemaHalls = new List<CinemaHall>();
            var city = await GetCity(cinemaViewModel.Address.City);

            cinemaViewModel.CinemaHalls.ForEach(x => cinema.CinemaHalls.Add(_cinemaHallFactory.CreateCinemaHall(x)));
            cinema.City = city;
            cinema.Address = _addressFactory.GetAddress(cinemaViewModel.Address);

            return cinema;
        }

        private async Task<City> GetCity(string cityName)
        {
            return await _cityRepo.FindCity(cityName);
        }
    }
}
