using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class ChooseCinemaForBookingViewModel
    {
        public int MovieId { get; set; }
        public List<SearchCinemaViewModel> Cinemas { get; set; }

        public ChooseCinemaForBookingViewModel(List<Cinema> cinemas, int movieId)
        {
            Cinemas = new List<SearchCinemaViewModel>();
            MovieId = movieId;
            cinemas.ForEach(x => Cinemas.Add(new SearchCinemaViewModel(x)));
        }

        public ChooseCinemaForBookingViewModel()
        {

        }
    }
}
