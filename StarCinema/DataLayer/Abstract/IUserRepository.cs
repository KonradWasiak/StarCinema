﻿using StarCinema.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.DataLayer.Abstract
{
    public interface IUserRepository
    {
        Task<StarCinemaUser> GetUser(string username);
    }
}