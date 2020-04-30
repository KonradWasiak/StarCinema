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
        private readonly StarCinemaContext _context;

        public UserRepository(StarCinemaContext context)
        {
            _context = context;
        }

        public StarCinemaUser GetUser(string username)
        {
            var user = this._context.Users.FirstOrDefault(u => u.UserName == username);
            return user;

        }

        public IList<StarCinemaUser> GetPaginatedUsers(int page, int pageSize, string orderBy)
        {
            var allUsers = _context.Users.ToList();
            switch (orderBy)
            {
                case "UserAsc":
                    allUsers = allUsers.OrderBy(x => x.UserName).ToList();
                    break;
                case "UserDesc":
                    allUsers = allUsers.OrderByDescending(x => x.UserName).ToList();
                    break;
                default:
                    allUsers = allUsers.OrderBy(x => x.UserName).ToList();
                    break;
            }

            return allUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetUsersCount()
        {
            return _context.Users.Count();
        }
    }
}
