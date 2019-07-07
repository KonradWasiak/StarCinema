using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class PaginatedCitiesViewModel
    {
        public PaginatedCitiesViewModel(IEnumerable<CityViewModel> cities, PagingInfo pagingInfo)
        {
            this.Cities = cities;
            this.PagingInfo = pagingInfo;
        }
        public IEnumerable<CityViewModel> Cities { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
