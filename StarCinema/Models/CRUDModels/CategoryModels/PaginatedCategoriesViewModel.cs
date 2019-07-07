using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class PaginatedCategoriesViewModel
    {
        public PaginatedCategoriesViewModel(IEnumerable<CategoryViewModel> categories, PagingInfo pagingInfo)
        {
            Categories = categories;
            PagingInfo = pagingInfo;
        }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
