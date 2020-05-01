using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarCinema.Areas.Identity.Data;
using StarCinema.DataLayer.Abstract;
using StarCinema.Models;
using StarCinema.Models.CRUDModels.UserModels;

namespace StarCinema.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<StarCinemaUser> _userManager;

        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager, UserManager<StarCinemaUser> userManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users(UserListingRequest request)
        {
            var users = _userRepository.GetPaginatedUsers(request.Page, request.PageSize, request.OrderBy).ToList();
            var userListingRows = new List<UserListingRowViewModel>();
            users.ForEach(x => userListingRows.Add(new UserListingRowViewModel(x)));

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any(x => x.Equals("Admin")))
                {
                    userListingRows.Where(x => x.Username == user.UserName).FirstOrDefault().IsAdmin = true;
                }
            }
            
            var userListingViewModel = new ListingViewModel<UserListingRowViewModel>(userListingRows, request.Page, _userRepository.GetUsersCount(), request.OrderBy);
            return View(userListingViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUserRole(string username, bool isAdmin)
        {                
            var user = _userRepository.GetUser(username);

            if (isAdmin)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Users");
            }

            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> AddAdmin()
        {
            if (_userRepository.GetUser("Administrator") == null)
            {
                var user = new StarCinemaUser()
                {
                    UserName = "Administrator",
                    Email = "konwasiak@gmail.com",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(user, "`3zVhy/5");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return RedirectToAction("Users");
        }


    }
}