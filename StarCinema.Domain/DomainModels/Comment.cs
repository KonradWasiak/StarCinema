using StarCinema.Areas.Identity.Data;
using System;

namespace StarCinema.DomainModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public StarCinemaUser User { get; set; }

    }
}