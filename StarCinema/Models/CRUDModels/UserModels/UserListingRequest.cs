using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.UserModels
{
    public class UserListingRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 2;
        public string OrderBy { get; set; } = "UserAsc";
    }
}
