using StarCinema.Areas.Identity.Data;
using StarCinema.Models.BookingModels;
using StarCinema.Models.CRUDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.UserModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<RateViewModel> Rates { get; set; }
        public List<BookingViewModel> Bookings { get; set; }

        public UserViewModel(StarCinemaUser user)
        {
            this.UserName = user.UserName;
            this.Email = user.Email;

            if(this.Comments == null)
            {
                this.Comments = new List<CommentViewModel>();
                user.Comments.ToList()
                    .ForEach(x => this.Comments.Add(new CommentViewModel(x)));
            }
            
            if(this.Rates == null)
            {
                this.Rates = new List<RateViewModel>();
                user.Rates.ToList()
                    .ForEach(x => this.Rates.Add(new RateViewModel(x)));
            }
            
            if(this.Bookings == null)
            {
                this.Bookings = new List<BookingViewModel>();
                user.Bookings.ToList()
                    .ForEach(x => this.Bookings.Add(new BookingViewModel(x)));
            }
        }

    }
}
