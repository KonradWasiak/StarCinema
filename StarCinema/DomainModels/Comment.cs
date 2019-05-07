﻿using StarCinema.Areas.Identity.Data;

namespace StarCinema.DomainModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual StarCinemaUser User { get; set; }

    }
}