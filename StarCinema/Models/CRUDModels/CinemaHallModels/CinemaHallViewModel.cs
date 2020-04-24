using StarCinema.DomainModels;
using StarCinema.Models.CRUDModels.CinemaModels;
using StarCinema.Models.CRUDModels.SeatModels;
using StarCinema.Models.CRUDModels.ShowModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaHallModels
{
    public class CinemaHallViewModel
    {
        public int Id { get; set; }
        public int SeatsCount { get; set; }
        public string Name { get; set; }
        public CinemaViewModel Cinema { get; set; }
        public List<SeatViewModel> Seats { get; set; }
        public List<ShowListingRowViewModel> Shows { get; set; }

        public CinemaHallViewModel(CinemaHall cinemaHall)
        {
            this.Id = cinemaHall.Id;
            this.SeatsCount = cinemaHall.Seats.Count();
            
            if(this.Cinema == null)
            {
                this.Cinema = new CinemaViewModel(cinemaHall.Cinema);
            }

            if(this.Seats == null)
            {
                this.Seats = new List<SeatViewModel>();
                cinemaHall.Seats.ToList()
                    .ForEach(x => this.Seats.Add(new SeatViewModel(x)));
            }

            if (this.Shows == null)
            {
                //this.Shows = new List<ShowListingViewModel>();
                //cinemaHall.Shows.ToList()
                //    .ForEach(x => this.Shows.Add(new ShowListingViewModel(x)));
            }
        }

        public CinemaHallViewModel()
        {

        }
    }
}
