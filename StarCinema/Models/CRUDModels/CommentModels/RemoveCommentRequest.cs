using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class RemoveCommentRequest
    {
        public int MovieId { get; set; }
        public int CommentId { get; set; }
    }
}
