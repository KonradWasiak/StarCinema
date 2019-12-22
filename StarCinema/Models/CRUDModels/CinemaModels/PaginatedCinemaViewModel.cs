using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaModels
{
    public class PaginatedCinemaViewModel
    {
        public PaginatedCinemaViewModel(IEnumerable<CinemaViewModel> cinemas, PagingInfo pagingInfo)
        {
            Cinemas = cinemas;
            PagingInfo = pagingInfo;
        }

        public IEnumerable<CinemaViewModel> Cinemas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
