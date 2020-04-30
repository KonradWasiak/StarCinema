using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.RateModels
{
    public class AddRateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public bool ThumbUp { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
