using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.CinemaHallModels
{
    public class EditCinemaCinemaHallViewModel
    {
        public int HallId { get; set; }
        public string Name { get; set; }
        public int SeatsCount { get; set; }
    }
}
