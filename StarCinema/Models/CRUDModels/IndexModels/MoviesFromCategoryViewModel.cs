using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.IndexModels
{
    public class MoviesFromCategoryViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<Movie> MoviesFromCategory { get; set; }
    }
}
