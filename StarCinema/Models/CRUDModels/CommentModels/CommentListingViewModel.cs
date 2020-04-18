using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class CommentListingViewModel : ListingViewModel<CommentsListingRowViewModel>
    {
        public CommentListingViewModel(IEnumerable<CommentsListingRowViewModel> models, int movieId, int page, int modelsCount, string orderBy)
            : base(models, page, modelsCount, orderBy)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }
    }
}
