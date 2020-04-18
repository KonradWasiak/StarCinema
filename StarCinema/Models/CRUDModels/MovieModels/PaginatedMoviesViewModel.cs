using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.IndexModels
{
    public class PaginatedMoviesViewModel
    {
        public IEnumerable<AddEditMovieRequest> Movies { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public PaginatedMoviesViewModel(IEnumerable<AddEditMovieRequest> movies, PagingInfo pagingInfo)
        {
            Movies = movies;
            PagingInfo = pagingInfo;
        }
    }
}
