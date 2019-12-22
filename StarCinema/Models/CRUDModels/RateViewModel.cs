using StarCinema.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public class RateViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Rate { get; set; }

        public RateViewModel(Rate rate)
        {
            this.UserName = rate.User.UserName;
            this.Rate = rate.IfLike ? 1 : 0;
        }
    }
}
