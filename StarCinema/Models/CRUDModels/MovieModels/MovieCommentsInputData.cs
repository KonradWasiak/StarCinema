using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class MovieCommentsInputData
    {
        public int MovieId { get; set; }
        public int Page { get; set; }
    }
}
