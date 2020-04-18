using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.AddressModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }
        public int CityId{ get; set; }
        public List<CinemaHallViewModel> CinemaHalls { get; set; }
        public AddressViewModel Address { get; set; }
        public CinemaViewModel()
        {
            this.CinemaHalls = new List<CinemaHallViewModel>();
            Address = new AddressViewModel();
        }

        public static CinemaViewModel CreateListCinemaViewModel(Cinema cinemaEntity)
        {
            var cinemaViewModel = new CinemaViewModel()
            {
                Id = cinemaEntity.Id,
                Address = new AddressViewModel(cinemaEntity.Address),
                CinemaHalls = new List<CinemaHallViewModel>()
            };
            return cinemaViewModel;
        }

        //private CinemaHallViewModel CreateCinemaHallsForList(CinemaHall cinemaHallEntity)
        //{
        //    return new CinemaHallViewModel()
        //    {
        //        Name = cinemaHallEntity.Name,
        //        Seats = cinemaHallEntity.
        //    }
        //}

        public CinemaViewModel(Cinema cinemaEntity)
        {

        }
    }
}
