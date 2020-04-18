using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CommentModels
{
    public class AddComentRequest
    {
        public int MovieId { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
    }
}
