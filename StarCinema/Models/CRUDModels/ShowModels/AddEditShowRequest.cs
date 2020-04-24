using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.ShowModels
{
    public class AddEditShowRequest
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime Date { get; set; }
    }
}
