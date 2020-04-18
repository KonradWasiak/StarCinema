using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public class ListingViewModel <T>
    {
        public ListingViewModel(IEnumerable<T> models, int page, int modelsCount, string orderBy)
        {
            Models = models;
            PagingInfo = new PagingInfo(modelsCount, page);
            OrderBy = orderBy;
        }

        public string OrderBy { get; set; }
        public IEnumerable<T> Models { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
