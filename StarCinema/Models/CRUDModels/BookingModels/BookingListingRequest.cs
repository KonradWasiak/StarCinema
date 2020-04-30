using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.BookingModels
{
    public class BookingListingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 2;
        public string OrderBy { get; set; } = "DateDesc";
        public int MovieId { get; set; }
    }
}
