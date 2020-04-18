using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class AddComentViewModel
    {
        public int MovieId { get; set; }
        public AddComentRequest Request { get; set; }
    }
}
