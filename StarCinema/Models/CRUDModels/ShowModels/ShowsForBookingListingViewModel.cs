using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class ShowsForBookingListingViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public List<ShowForBookingRowViewModel> Shows { get; set; }

        public ShowsForBookingListingViewModel(int movieId, string movieTitle, List<Show> shows)
        {
            Shows = new List<ShowForBookingRowViewModel>();
            MovieTitle = movieTitle;
            MovieId = movieId;
            shows.ForEach(x => Shows.Add(new ShowForBookingRowViewModel(x)));
        }
    }
}
