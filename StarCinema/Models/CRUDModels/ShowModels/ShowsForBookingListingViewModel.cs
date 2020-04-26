using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class ShowsForBookingListingViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, ShowForBookingRowViewModel> Shows { get; set; }
    }
}
