using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; } = 2;
        public int TotalPages { get; set; }
        private void CalculatePagesCount(int totalCount)
        {
            TotalPages = totalCount % ItemsPerPage > 0 ? totalCount / ItemsPerPage + 1 : totalCount / ItemsPerPage;
        }

        public PagingInfo(int totalCount, int currentPage, int itemsPerPage)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            CalculatePagesCount(totalCount);
        }
        public PagingInfo(int totalCount, int currentPage)
        {
            CurrentPage = currentPage;
            CalculatePagesCount(totalCount);
        }
    
    
    }
    
}
