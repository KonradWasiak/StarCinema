using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CategoryModels
{
    public class CategoryListingRequest
    {
        public string OrderBy { get; set; } = "NameAsc";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
