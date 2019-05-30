using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public PagingInfo(int itemsPerPage)
        {
            this.ItemsPerPage = itemsPerPage;
        }
    }
}
