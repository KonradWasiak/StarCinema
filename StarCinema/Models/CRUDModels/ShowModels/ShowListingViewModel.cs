using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.Models.CRUDModels.ShowModel;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class ShowListingViewModel
    {
        public string OrderBy { get; set; }
        public IList<ShowListingRowViewModel> Models { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int MovieId { get; set; }
        public ShowListingViewModel(IList<ShowListingRowViewModel> models, int page, int modelsCount, string orderBy, int movieId)
        {
            Models = models;
            PagingInfo = new PagingInfo(modelsCount, page);
            OrderBy = orderBy;
            MovieId = movieId;
        }
    }
}
