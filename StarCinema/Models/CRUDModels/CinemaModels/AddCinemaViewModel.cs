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
    public class AddCinemaViewModel : CinemaViewModel
    {
        public List<SelectListItem> AllCities { get; set; }
        public int HallsCount { get; set; }
        public AddCinemaViewModel(List<City> citites)
        {
            AllCities = new List<SelectListItem>();
            citites.ForEach(c => AllCities.Add(GetCitySelectListItem(c)));
        }
        public AddCinemaViewModel(Cinema cinema) : base(cinema)
        {
            this.AllCities = new List<SelectListItem>();
        }

        public AddCinemaViewModel()
        {
        }
        private SelectListItem GetCitySelectListItem(City city)
        {
            return new SelectListItem()
            {
                Text = city.CityName,
                Value = city.CityName
            };
        }

        public async Task CreateCinemaHalls(ICityRepository repo)
        {
            var city = await repo.FindCity(this.Address.City);
            this.City = new CityViewModel(city);
            for (int i = 0; i < HallsCount; i++)
            {
                CinemaHalls.Add(new CinemaHallViewModel() 
                { 
                    Cinema = this as CinemaViewModel,
                    Shows = new List<ShowViewModel>()
                });
            }
        }

        public void CreateSeatsInHalls()
        {
            this.CinemaHalls.ForEach(x => x.Seats = CreateEmptySeats(x, x.SeatsCount));
        }

        private List<SeatViewModel> CreateEmptySeats(CinemaHallViewModel hall, int count)
        {
            var seats = new List<SeatViewModel>();
            for (int i = 0; i < count; i++) {
                seats.Add(new SeatViewModel()
                {
                    Available = true,
                    Hall = hall
                });
            }
            return seats;
        }
    }
}
