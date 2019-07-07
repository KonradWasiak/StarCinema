using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public static int ItemsPerPage = 2;
        public int TotalPages { get; set; }
    }
}
