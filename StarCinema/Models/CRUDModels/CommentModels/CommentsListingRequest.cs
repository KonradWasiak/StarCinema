using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class CommentsListingRequest
    {
        [Required]
        public int MovieId { get; set; }

        public int PageSize { get; set; } = 2;
        public int Page { get; set; } = 1;
        public string OrderBy { get; set; } = "";
    }
}
