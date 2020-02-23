using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public class PaginatedViewModel <T>
    {
        public PaginatedViewModel(IEnumerable<T> models, int page, int modelsCount)
        {
            Models = models;
            PagingInfo = new PagingInfo(modelsCount, page);
        }

        public IEnumerable<T> Models { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
