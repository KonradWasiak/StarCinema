using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StarCinema.Areas.Identity.Data;

namespace StarCinema.Models.CRUDModels.UserModels
{
    public class UserListingRowViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public UserListingRowViewModel(StarCinemaUser user)
        {
            Username = user.UserName;
            Email = user.Email;
        }
    }
}
