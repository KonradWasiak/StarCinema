using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class MovieListingRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public string OrderBy { get; set; }
        public int CategoryId { get; set; }
    }
}
