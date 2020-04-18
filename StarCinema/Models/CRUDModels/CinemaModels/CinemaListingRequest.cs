using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class CinemaListingRequest
    {
        public string OrderBy { get; set; } = "CityAsc";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
