using Microsoft.EntityFrameworkCore;
using StarCinema.Areas.Identity.Data;
using StarCinema.DataLayer.Abstract;
using StarCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly StarCinemaContext context;

        public UserRepository(StarCinemaContext context)
        {
            this.context = context;
        }
        public StarCinemaUser GetUser(string username)
        {
            var user = this.context.Users.FirstOrDefault(u => u.UserName == username);
            return user;

        }
    }
}
