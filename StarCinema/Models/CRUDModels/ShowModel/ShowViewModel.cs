using StarCinema.DomainModels;
using StarCinema.Models.BookingModels;
using StarCinema.Models.CRUDModels.CinemaHallModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.ShowModel
{
    public class ShowViewModel
    {
        public int Id { get; set; }
        public AddEditMovieRequest AddEditMovie { get; set; }
        public CinemaHallViewModel Hall { get; set; }
        public DateTime Date { get; set; }
        public List<BookingViewModel> Bookings { get; set; }

        public ShowViewModel()
        {

        }
        //public ShowViewModel(Show show)
        //{
        //    this.Id = show.Id;
            
        //    if(this.AddEditMovie == null)
        //    {
        //        this.AddEditMovie = new AddEditMovieRequest(show.Movie);
        //    }

        //    if(this.Hall == null)
        //    {
        //        this.Hall = new CinemaHallViewModel(show.Hall);
        //    }

        //    if(this.Bookings == null)
        //    {
        //        this.Bookings = new List<BookingViewModel>();
        //        show.Bookings.ToList()
        //            .ForEach(x => this.Bookings.Add(new BookingViewModel(x)));
        //    }
        //}

    }
}
