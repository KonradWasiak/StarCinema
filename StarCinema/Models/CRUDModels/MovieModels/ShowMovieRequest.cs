using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.MovieModels
{
    public class ShowMovieRequest
    {
        public int MovieId { get; set; }
        public int CommentPage { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
